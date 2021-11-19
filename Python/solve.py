import sys
import numpy as np
import random
from flask import Flask, request


class Global:
    exploredMineTmpIdxs = []
    exploredMineIdxs = []
    exploredNotMineIdxs = []
    problem = None
    prevAction = None # dùng để lưu action ấn phải mìn trước đó


class Node:
    def __init__(self, action=None, xd=None, notMineActions=None, havingMineActions=None):
        self.action = action
        self.xd = xd
        self.notMineActions = notMineActions
        self.havingMineActions = havingMineActions


class Problem:
    def __init__(self, state, initAction=None):
        self.initAction = initAction
        self.state = state
        self.height = len(state)
        self.width = len(state[0])
        self.d = [-1, 0, 10, 20, 30, 40, 50, 60, 70, 80]

    def isValidCell(self, cell):
        if (len(cell) != 2):
            return False

        x = cell[0]
        y = cell[1]
        if (x >= 0 and x < self.height and
                y >= 0 and y < self.width):
            return True

        return False

    def getCellArround(self, count, currCell):
        if (count == 1):
            return [currCell[0]-1, currCell[1]-1]
        elif (count == 2):
            return [currCell[0]-1, currCell[1]]
        elif (count == 3):
            return [currCell[0]-1, currCell[1]+1]
        elif (count == 4):
            return [currCell[0], currCell[1]+1]
        elif (count == 5):
            return [currCell[0]+1, currCell[1]+1]
        elif (count == 6):
            return [currCell[0]+1, currCell[1]]
        elif (count == 7):
            return [currCell[0]+1, currCell[1]-1]
        elif (count == 8):
            return [currCell[0], currCell[1]-1]

    def isAllCellNotOpen(self):
        for i in range(0, len(self.state)):
            for j in range(0, len(self.state[i])):
                if (self.state[i][j] != -2):
                    return False

        return True

    def isOpened(self, cell):
        if (self.state[cell[0]][cell[1]] == -2):
            return False
        return True

    def nOfMinesAround(self, cell):
        nOfMines = 0

        for i in range(1, 9):
            cellTmp = self.getCellArround(i, cell)
            if (self.isValidCell(cellTmp) and
                    self.state[cellTmp[0]][cellTmp[1]] == -1):
                nOfMines += 1

        return nOfMines

    def nOfNotOpenedCellAround(self, cell):
        nOfNotOpened = 0

        for i in range(1, 9):
            cellTmp = self.getCellArround(i, cell)
            if (self.isValidCell(cellTmp) and
                    self.state[cellTmp[0]][cellTmp[1]] == -2):
                nOfNotOpened += 1

        return nOfNotOpened

    def nOfOpenedCellAround(self, cell):
        nOfOpened = 0

        for i in range(1, 9):
            cellTmp = self.getCellArround(i, cell)
            if (self.isValidCell(cellTmp) and
                    self.state[cellTmp[0]][cellTmp[1]] != -2 and
                    self.state[cellTmp[0]][cellTmp[1]] != -1):
                nOfOpened += 1
        return nOfOpened

    def isSurelyHavingMine(self, cell):
        if (self.state[cell[0]][cell[1]] != -2):
            return False

        """Kiểm tra các ô xung quanh xem đã đủ mìn chưa, nếu có một ô thỏa điều kiện: 
        - chỉ còn đúng 1 mìn để đủ 
        - chỉ có đúng một ô chưa mở ở cạnh nó """
        for i in range(1, 9):
            cellTmp = self.getCellArround(i, cell)
            if (self.isValidCell(cellTmp) and
                    # đk 1
                    self.state[cellTmp[0]][cellTmp[1]] - self.nOfMinesAround(cellTmp) == 1 and
                    self.nOfNotOpenedCellAround(cellTmp) == 1):  # đk 2
                return True

        return False

    def isSurelyHavingNoMine(self, cell):
        if (self.state[cell[0]][cell[1]] != -2):
            return True

        """
        Kiểm tra các ô xung quanh xem nó đã có đủ số mìn hết chưa, nếu đủ hết rồi thì True
        """
        for i in range(1, 9):
            cellTmp = self.getCellArround(i, cell)
            if (self.isValidCell(cellTmp) and
                    self.state[cellTmp[0]][cellTmp[1]] == self.nOfMinesAround(cellTmp)):
                return True
        return False


def solveMinesweeper(problem):  # -> Node -> action

    # Nếu tất cả các ô chưa mở
    if (problem.isAllCellNotOpen()):
        # Tạo XD
        xd = []
        for i in range(0, len(problem.state)):
            for j in range(0, len(problem.state[i])):
                # Tất cả các ô đều có cùng D khi bảng chưa có ô nào được mở
                xd.append([i, j, -1, 0, 10, 20, 30, 40, 50, 60, 70, 80]) 

        # Trường hợp tất cả các ô chưa mở nhưng là vì bị reset lại do đi sai 
        # => Sẽ có initAction
        if (problem.initAction != None or Global.prevAction != None):
            Global.exploredMineIdxs.append(
                [Global.prevAction[0], Global.prevAction[1]]) # Nhớ ô đã đi sai
            # Kiểm tra xem bước đi đầu tiên có phải là bước đụng phải mìn hay không
            # Nếu phải thì không chọn ô này nữa mà chọn random
            if (problem.initAction not in Global.exploredMineIdxs):
                return Node(problem.initAction, xd)

        # random action
        x = random.randint(0, len(problem.state)-1)
        y = random.randint(0, len(problem.state[0])-1)
        action = [x, y, 1]

        problem.initAction = action
        Global.prevAction = action
        return Node(action, xd)

    # Nếu đã có ô mở rồi 
    # Duyệt qua tất cả các ô để xác định và rút gọn miền giá trị cho nó
    xd = []
    for i in range(0, len(problem.state)):
        for j in range(0, len(problem.state[i])):
            if (problem.state[i][j] != -2 and problem.state[i][j] != -1): # nếu ô đó đã mở thì nhớ nó cho bước sau 
                if ([i,j] not in Global.exploredNotMineIdxs):
                    Global.exploredNotMineIdxs.append([i,j])

            if (problem.state[i][j] != -2):  # nếu ô đó đã mở hoặc đã đặt mìn
                xd.append([i, j])
            elif ([i, j] in Global.exploredMineIdxs): # nếu biết trước ô đó có mìn
                xd.append([i, j, -1])
                if ([i,j] in Global.exploredMineTmpIdxs and [i,j] not in Global.exploredMineIdxs):
                    Global.exploredMineIdxs.append([i,j])
                elif ([i,j] not in Global.exploredMineTmpIdxs): 
                    Global.exploredMineTmpIdxs.append([i,j])
            elif ([i, j] in Global.exploredNotMineIdxs): # nếu biết trước ô đó k có mìn
                xd.append([i, j, 0])
            elif (problem.nOfOpenedCellAround([i, j]) == 0): # nếu xung quanh ô đó chưa có ô nào mở
                xd.append([i, j, -1, 0, 10, 20, 30, 40, 50, 60, 70, 80])
            elif (problem.isSurelyHavingNoMine([i, j])): # nếu ô đó chắc chắn không có mìn
                xd.append([i, j, 0])
            elif (problem.isSurelyHavingMine([i, j])): # nếu ô đó chắc chắn có mìn
                xd.append([i, j, -1])
            else:  # nếu không rơi vào trường hợp nào thì đánh giá mức độ có mìn của ô đó
                xd.append([i, j, problem.nOfOpenedCellAround([i, j])*10])


    # lấy các ô chắc chắn k có mìn
    notMineActions = []
    for i in range(0, len(Global.exploredNotMineIdxs)):
        actionTmp = [Global.exploredNotMineIdxs[i][0], Global.exploredNotMineIdxs[i][1], 1]  # mở ô đó ra
        notMineActions.append(actionTmp)

    # lấy các ô chắc chắn có mìn
    havingMineActions = []
    for i in range(0, len(Global.exploredMineIdxs)):
        actionTmp = [Global.exploredMineIdxs[i][0], Global.exploredMineIdxs[i][1], 1]  # mở ô đó ra
        havingMineActions.append(actionTmp)

    # xác định action
    action = []
    highestMineRatio = 0
    for i in range(0, len(xd)):
        subXD = xd[i]
        if (len(subXD) == 3):
            if (subXD[2] == 0):  # tìm ô chắc chắn k có mìn
                action = [subXD[0], subXD[1], 1]  # mở ô đó ra
                break
            if (subXD[2] == -1):  # tìm ô chắc chắn có mìn
                action = [subXD[0], subXD[1], -1]  # đặt cờ
                break

            # Nếu k lấy được ô nào rơi vào 2 trường hợp trên:
            # lấy giá trị tỉ lệ có mìn cao nhất
            if (subXD[2] > highestMineRatio):
                highestMineRatio = subXD[2]

    """
    Nếu k tìm được ô nào chắc chắn có mìn hay k có mìn, 
    tìm ô có tỉ lệ có mìn cao nhất đầu tiên và đặt cờ 
    """
    if (action == []):
        for i in range(0, len(xd)):
            subXD = xd[i]
            if (len(subXD) == 3 and subXD[2] == highestMineRatio):
                action = [subXD[0], subXD[1], -1]  # đặt cờ
                break

    return Node(action, xd, notMineActions, havingMineActions)

class ActionDTO:
    def __init__(self, x, y, task, notMineActions=None, havingMineActions=None):
        self.x = x
        self.y = y
        self.task = task
        self.notMineActions = notMineActions
        self.havingMineActions = havingMineActions

    def toJson(self):
        return {"X": self.x, "Y": self.y, "task": self.task, "notMineActions": self.notMineActions, "havingMineActions": self.havingMineActions}

# GATEWAY
app = Flask(__name__)

@app.route('/', methods=['POST'])
def postRequest():
    state = request.get_json()['state'] # lấy state hiện tại của problem 
    start = request.get_json()['start']
    if (start == True): # kiểm tra xem bắt đầu ván mới hay là đi lại do chọn sai ô 
        problem = Problem(state)
        Global.problem = problem # Lưu lại problem gốc 
        Global.exploredMineTmpIdxs = []
        Global.exploredMineIdxs = [] 
        Global.exploredNotMineIdxs = []
        Global.prevAction = None
    else:
        problem = Problem(state, Global.problem.initAction)
    
    node = solveMinesweeper(problem) # Thuật toán chính. Tìm action tiếp theo

    if (node.action == []): # Nếu đã giải thành công
        return ActionDTO(0, 0, 10).toJson()

    action = ActionDTO(node.action[0], node.action[1], node.action[2], node.notMineActions, node.havingMineActions)
    # Kiểm tra action tiếp theo có phải là mở ô không, nếu là mở ô thì lưu vào prevAction 
    # để phòng trường hợp ấn phải mìn thì lưu lại 
    if (node.action[2] == 1):  
        Global.prevAction = [node.action[0], node.action[1]]
    return action.toJson()


if __name__ == '__main__':
    app.run()
    # state = [[-2, -2, -2, -2],
    #          [-2, -2, -2, -2],
    #          [-2, -2, -2, -2],
    #          [-2, -2, -2, -2]]

    # while True:
    #     if (Global.problem == None):
    #         problem = Problem(0, state)
    #         Global.problem = problem
    #     else:
    #         problem = Problem(0, state, Global.problem.initAction)
    #     node = solveMinesweeper(problem)
