'use strict'

var connection = new signalR.HubConnectionBuilder().withUrl("/discordHub").build()

connection.on("ReceiveBotStatus", message => {
    document.getElementById("botStatus").innerText = message
    var powerButton = document.getElementById("powerButton")
    console.log(message)
    switch (message) {
        case "Online":
            powerButton.innerText = "Turn off"
            powerButton.classList.replace(/btn-[a-z]/, "btn-danger")
            break;
        case "Offline":
            powerButton.innerText = "Turn on"
            powerButton.classList.replace(/btn-[a-z]/, "btn-succes")
            break;
        case "Starting":
            powerButton.innerText = "Starting..."
            powerButton.classList.replace(/btn-[a-z]/, "btn-warning")
            break;
    }
})

connection.start().then(() => {
    console.log("connected to hub")
    connection.invoke("GetBotStatus").catch(error => {
        return console.error(error)
    })
}).catch(error => {
    console.error(error)
})

document.addEventListener("load", event => {
})
