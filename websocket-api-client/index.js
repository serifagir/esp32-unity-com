const WebSocket = require("ws")
var uuid = require("uuid-random")


const wsserver = new WebSocket.WebSocketServer({ port: 8080 }, () => {
    console.log("Server started")
})

const espdata = {
    "accx": 13,
    "accy": 60,
    "vib": 14,
    "type": "espdata",
}

wsserver.on("connection", (ws) => {
    ws.on("message", (data) => {
        console.log('data received %o' + data.toString())
        ws.send(espdata.toString())
    })
})

wsserver.on("listening", () =>
    console.log(`Server listening on port 8080`)
)

