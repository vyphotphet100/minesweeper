import flask as fl

app = fl.Flask(__name__)
app.config["DEBUG"] = True


@app.route('/', methods=['GET'])
def home():
    return "<h1>Distant Reading Archive</h1><p>This site is a prototype API for distant reading of science fiction novels.</p>"


action = {
    "X": "1",
    "Y": "2",
    "task": "-1"
}


@app.route('/gethint', methods=['POST'])
def acitonTest():
    data = fl.request.get_json()
    print(data)
    return fl.jsonify(action)


# @app.route('/thien', methods=['POST'])
# def stateTest():
#     data = fl.request.get_json()
#     # Call you fuction here and return action to client

#     return data

# @app.route('/dat', methods=['POST'])
# def stateTest():
#     data = fl.request.get_json()
#     # Call you fuction here and return action to client

#     return data


app.run()
