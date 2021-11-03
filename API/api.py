import flask as fl
import json

app = fl.Flask(__name__)
app.config["DEBUG"] = True


@app.route('/', methods=['GET'])
def home():
    return "<h1>Distant Reading Archive</h1><p>This site is a prototype API for distant reading of science fiction novels.</p>"


action = {
    "X": "1",
    "Y": "2"
}


@app.route('/actionTest', methods=['GET'])
def acitonTest():
    action
    return fl.jsonify(action)


@app.route('/stateTest', methods=['GET'])
def stateTest():
    data = fl.request.json()
    print(data)
    return json.dumps({'success':True}), 200, {'ContentType':'application/json'} 


app.run()
