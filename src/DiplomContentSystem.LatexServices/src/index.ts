import { getPackageVersion, getSample } from './my-lib';
import { Request, Response } from "express"
import { Stream } from "stream";
import * as _express from "express"
import * as _bodyParser from "body-parser";
import * as bodyParser from 'body-parser';
console.log("DiplomContentSystem LaTeX->PDF Service");
console.log(getPackageVersion());

// server.js

// BASE SETUP
// =============================================================================

// call the packages we need
let latex = require("latex");
let cors = require("cors");
// define our app using express
let app = _express();


// configure app to use bodyParser()
// this will let us get the data from a POST
app.use(_bodyParser.json({strict:false}));
app.use(_bodyParser.urlencoded({ extended: true }));
app.use(cors());

var port = process.env.PORT || 1337;        // set our port

// ROUTES FOR OUR API
// =============================================================================
var router = _express.Router();              // get an instance of the express Router

// test route to make sure everything is working (accessed at GET http://localhost:8080/api)
router.get('/sample', function (request: Request, response: Response) {
    let data = getSample();
    response.setHeader('Content-type', 'application/pdf');
    response.setHeader('Content-disposition', 'attachment; filename=file.pdf');
    let result = (<Stream>latex(data)).pipe(response);
});
router.post('/convert', function (request: Request, response: Response) {

    const data = (request.body.data)?request.body.data.toString():null;
    if(!data)
    {
        response.status(400).end();
        return;
    }
    response.setHeader('Content-type', 'application/pdf');
    let filename = new Date().toISOString();
    response.setHeader('Content-disposition', 'attachment; filename='+filename+'.pdf');
    (<Stream>latex(data)).pipe(response);
});
// more routes for our AжPI will happen here

// REGISTER OUR ROUTES -------------------------------
// all of our routes will be prefixed with /api
app.use('/api', router);
// starting our server
app.listen(port);
console.log('Application started on port ' + port);