import prompt from "prompt-sync";

class NotRobot extends Handler {
    handle(request) {
        function getRandomInt(max) {
            return Math.floor(Math.random() * max);
        }
        let a = getRandomInt(100);
        let b = getRandomInt(100);
        console.log(`${a} + ${b} = `);
        let sum = a + b;
        let counter = 3;
        for (let i = 0; i < counter; i++) {
            const readline = prompt();
            const sum_user = readline("Sum = ");
            if (sum_user == sum) {
                return super.handle(request);
            }
            console.log("Wrong number");
        }
        return null;
    }
}
class AuthorizeHandler extends Handler {

    check(login, password) {
        return login == "user" && password == "user";
    }

    handle(request) {
        console.log("Authorize");

        let counter = 3;

        for (let i = 0; i < counter; i++) {
            const readline = prompt();
            const login = readline("Enter login - ");
            const password = readline("Enter password - ")
            if (this.check(login, password)) {
                return super.handle(request);

            } else {
                console.log("Wrong login or password");

            }
        }
        return null;

    }
}
class SmsHandler extends Handler {

    handle(request) {
        function getRandomString(length) {
            var randomChars = '0123456789';
            var result = '';
            for (var i = 0; i < length; i++) {
                result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
            }
            return result;
        }
        let sms = getRandomString(6);
        console.log(sms);
        let counter = 3;
        for (let i = 0; i < counter; i++) {
            const readline = prompt();
            const sms_user = readline("Enter the received code = ");
            if (sms_user == sms) {
                return super.handle(request);
            }
            console.log("Wrong code");
        }
        return null;
    }
}
class ResponceHandler extends Handler {
    handle(request) {
        console.log("Привіт");
        return "";
    }
}

export { LogHandler, NotRobot, AuthorizeHandler, SmsHandler, ResponceHandler };
