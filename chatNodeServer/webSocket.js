const webSocket = require('ws')

const ws = new webSocket.Server({port : 3010})

ws.on('connection', (connection) => {
    //console.log("new  connection")
    connection.on('message',(data) => {
        
        ws.clients.forEach((client)=> {
            client.send(data)
        })
    })
})