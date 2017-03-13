import * as _express from "express";
import * as _bodyParser from "body-parser";
import * as _cors from "cors";
import * as _morgan from "morgan";
import { Request, Response } from "express"
import { RouteHandler } from "./route-handler";
export class Server {
    public readonly app: _express.Express;
    public readonly port: number;
    public readonly router: _express.Router;
    private routeHandler: RouteHandler = new RouteHandler();

    constructor(port?: number) {
        this.port = port || process.env.PORT || 1337;
        this.app = _express();
        this.router = _express.Router();
    }

    public useDefaultConfig(): Server {
        this.app.use(_bodyParser.json());
        this.app.use(_cors());      
        this.app.use(_morgan("dev"));

        this.router.get("/sample", (request: Request, response: Response) => {
            this.routeHandler.sample(request, response);
        });
        this.router.post("/convert", (request: Request, response: Response) => {
            this.routeHandler.convert(request, response);
        });
        this.app.use("/api", this.router);
        
        this.app.use((error:any,request:Request,response:Response,next:any)=>{
            response.status(500);
            console.error(error);
            response.end();
        });
        return this;
    }

    public run() {
        this.app.listen(this.port);
        console.log("Application started on port " + this.port);
    }
}