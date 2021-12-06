import socket
import json
import base64

f = open("file.py")
data = f.read()

data = base64.b64encode(data)

payload = {"Id": 1, "Name":"file", "Data": data}

clientSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM);

clientSocket.connect(("10.0.2.2",12345));

clientSocket.send(json.dumps(payload));