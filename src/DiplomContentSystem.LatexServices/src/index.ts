import { getPackageVersion } from './my-lib';
import { Request,Response } from "express"
import * as _express from "express";
import * as _bodyParser from "body-parser";

console.log("DiplomContentSystem LaTeX->PDF Service");
console.log(getPackageVersion());

// server.js

// BASE SETUP
// =============================================================================

// call the packages we need
// define our app using express
let app = _express();
             

// configure app to use bodyParser()
// this will let us get the data from a POST
app.use(_bodyParser.urlencoded({extended:true}));
app.use(_bodyParser.json());

var port = process.env.PORT || 1337;        // set our port

// ROUTES FOR OUR API
// =============================================================================
var router =  _express.Router();              // get an instance of the express Router

// test route to make sure everything is working (accessed at GET http://localhost:8080/api)
router.post('/', function(request:Request, response:Response) {
    
    response.json({ echo: request.body.data });   
});

// more routes for our API will happen here

// REGISTER OUR ROUTES -------------------------------
// all of our routes will be prefixed with /api
app.use('/api', router);

// START THE SERVER
// =============================================================================
app.listen(port);
console.log('Application started on port ' + port);