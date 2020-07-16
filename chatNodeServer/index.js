const express = require('express')
const cors = require('cors')

const bodyParser = require('body-parser')
const app = express()

const fs = require('fs')


app.use((req,res,next) => {
    res.header('Access-Control-Allow-Origin', '*')
    res.header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS')
    res.header('Access-Control-Allow-Headers', '*')
    next()
})

app.use(bodyParser.json())

app.get('/',(req,res) => {
    res.json({msg:"bienvenue sur l'api"})
})

const getUsers = () => {
    const contentUsersJson = fs.readFileSync("data/users.json")
    const users = JSON.parse(contentUsersJson)
    return users
}

const getChannels = () => {
    const contentChannelsJson = fs.readFileSync("data/channels.json")
    const channels= JSON.parse(contentChannelsJson)
    return channels
}
const getMessages = () => {
    const contentMessagesJson = fs.readFileSync("data/messages.json")
    const messages= JSON.parse(contentMessagesJson)
    return messages
}
const saveUsers = (data) => {
    fs.writeFileSync("data/users.json", JSON.stringify(data))
}
const saveChannels = (data) => {
    fs.writeFileSync("data/channels.json", JSON.stringify(data))
}

const saveMessages = (data) => {
    fs.writeFileSync("data/messages.json", JSON.stringify(data))
}

//Gestion des utilisateurs
app.post('/user',(req,res) => {
    const user = req.body 
    const userExist = getUsers().find(element=>element.name == user.name)
    let result
    if(userExist == undefined) {
        const tmpUsers = [...getUsers(),user]
        saveUsers(tmpUsers)
        result = 'user created'
    }
    else {
        result = 'user exist'
    }
    res.json({msg : result})
})

//Gestion des channels
app.get('/channels', (req,res)=> {
    res.json(getChannels())
})

app.post('/channel', (req,res)=> {
    const channel = req.body
    const channelExist = getChannels().find(element => element.name == channel.name)
    let result
    if(channelExist == undefined) {
        const tmpChannels = [...getChannels(), channel]
        saveChannels(tmpChannels)
        result = 'channel created'
    }
    else {
        result = 'channel exist'
    }
    res.json({msg : result})
})

//Gestion des messages
app.get('/message/:channelName', (req,res) => {
    const messages = getMessages().filter(m=> m.channel == req.params.channelName)
    res.json(messages)
})

app.post('/message', (req, res) => {
    const message = req.body
    const tmpMessages = [...getMessages(),message] 
    saveMessages(tmpMessages)
    res.json({msg : 'message created'})
})

app.listen(80,function(){
    // console.log("une nouvelle connexion")
})