import { Request, Response } from "express"
import { Stream } from "stream"
import { Converter } from "./converter";
export class RouteHandler {
    private converter: Converter;
    constructor() {
        this.converter = new Converter();
    }
    public sample(request: Request, response: Response) {
        response.setHeader("Content-type", "application/pdf");
        response.setHeader("Content-disposition", "attachment; filename=file.pdf");
        this.converter.convert("").pipe(response);
    }
    public convert(request: Request, response: Response) {
        const filename = new Date().toDateString();
        const data = request.body.data.toString();
        response.setHeader("Content-Type", "application/pdf");
        response.setHeader("Content-Disposition", "attachment; filename=\"" + filename + ".pdf\"");
        this.converter.convert(data).pipe(response);
    }
}