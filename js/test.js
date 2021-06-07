//import { LogHandler, AuthorizeHandler, ResponceHandler } from "./chain.js";

import { LogHandler, NotRobot, AuthorizeHandler, SmsHandler, ResponceHandler } from "./chain.js";
export default {
    testCahinOfResposibility() {
        let chain = new LogHandler();
        chain
            .setNext(new NotRobot())
            .setNext(new AuthorizeHandler())
            .setNext(new SmsHandler())
            .setNext(new ResponceHandler());
        console.log(chain.handle());

    }
}