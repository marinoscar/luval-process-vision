class EventHandler {
    constructor() { }

    registerEvents() {
        $('#btn_login').on('click', function () {
            let msg = new MessageHandler();
            msg.showAll();
        });
    }
}

class MessageHandler {
    constructor() { }


    showAll() {
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 7; j++) {
                var msg = this.getMessage(j);
                this.showMessage(i + 1, msg);
            }
        }
    }

    showRandomMessage() {
        var type = this.getRandomNumber(1, 3);
        return this.showMessage(type, this.getRandomMessage());
    }

    showMessage(type, message) {
        switch (type) {
            case 1:
                return confirm(message);
            case 2:
                return prompt(message);
            default:
                return alert(message);
        }
    }

    getMessage(index) {
        var msg = [
            "You need to click here for a test",
            "Can you please help me with a click",
            "In order for me to test this new computer vision API I need a click",
            "I was wondering if you can be so kind to click on this box",
            "I also need to try how this is going to work with\nMultiple lines in a single box, my expectation is that\n there is not going to be any problems\n     let's hope I'm right\nLooking forward to see how this works out",
            "Another example that uses multiple lines\nPlease read this message and let's see if the computer vision manages to find the right element to click",
            "One more try to see if this works as expected",
            "This test is going to work\nI can feel it!!!"]
        return msg[index];
    }

    getRandomMessage() {
        var index = this.getRandomNumber(0, 7);
        return this.getMessage(index);
    }

    getRandomNumber(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}