import { getPackageVersion, getSample } from './my-lib';
import { Request, Response } from "express"
import { Stream } from "stream";
import * as _express from "express"
import * as _bodyParser from "body-parser";
console.log("DiplomContentSystem LaTeX->PDF Service");
console.log(getPackageVersion());

// server.js

// BASE SETUP
// =============================================================================

// call the packages we need
let latex = require("latex");
// define our app using express
let app = _express();


// configure app to use bodyParser()
// this will let us get the data from a POST
app.use(_bodyParser.urlencoded({ extended: true }));
app.use(_bodyParser.json());

var port = process.env.PORT || 1337;        // set our port

// ROUTES FOR OUR API
// =============================================================================
var router = _express.Router();              // get an instance of the express Router

// test route to make sure everything is working (accessed at GET http://localhost:8080/api)
router.get('/', function (request: Request, response: Response) {
    //let data:string = (request.body!=null)?request.body.data:"";
    let data = getSample();
    response.setHeader('Content-type', 'application/pdf');
    response.setHeader('Content-disposition', 'attachment; filename=file.pdf');
    let result = (<Stream>latex(data)).pipe(response);
});

// more routes for our AжPI will happen here

// REGISTER OUR ROUTES -------------------------------
// all of our routes will be prefixed with /api
app.use('/api', router);

// START THE SERVER
// =============================================================================
app.listen(port);
console.log('Application started on port ' + port);