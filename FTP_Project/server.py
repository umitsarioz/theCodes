from pyftpdlib.authorizers import DummyAuthorizer
from pyftpdlib.handlers import FTPHandler
from pyftpdlib.servers import FTPServer

authorizer = DummyAuthorizer()
authorizer.add_user("umit", "141180059", "./Remote/umit", perm="elradfmw")
authorizer.add_anonymous("./Remote/anonim", perm="elradfmw")

handler = FTPHandler
handler.authorizer = authorizer

server = FTPServer(("127.0.0.1", 1080), handler)
server.serve_forever()