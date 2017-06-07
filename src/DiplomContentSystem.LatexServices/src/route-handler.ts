import { Request, Response } from "express"
import { Stream } from "stream"
import { Converter } from "./converter";

let JSZip = require('jszip');
let Docxtemplater = require('docxtemplater');
let fs = require('fs');
let path = require('path');

export class RouteHandler {
    private converter: Converter;
    constructor() {
        this.converter = new Converter();
    }
    public sample(request: Request, response: Response) {
        // response.setHeader("Content-type", "application/pdf");
        // response.setHeader("Content-disposition", "attachment; filename=file.pdf");
        //this.converter.convert("").pipe(response);
        response.end("Hello,world!");
    }
    public convert(request: Request, response: Response) {
        try {
            const filename = new Date().toDateString();
            const data = request.body.data.toString();
            response.setHeader("Content-type", "application/pdf");
            response.setHeader("Content-disposition", "attachment; filename=\"" + filename + ".pdf\"");
            this.converter.convert(data).pipe(response);
        } catch (e) {
            response.status(500);
        }
    }
    public docx(request: Request, response: Response): void {
        try {

            let content = fs
                .readFileSync(path.resolve(__dirname, "..", "templates", "docx", 'calendar.docx'), 'binary');
            //console.log(content);
            let zip = new JSZip(content);
            let doc = new Docxtemplater();
            doc.loadZip(zip);
            const data = request.body;
            doc.setData(data);
            console.log(data.stages[0].startDate instanceof Date);
            try {
                doc.render()
            }
            catch (error) {
                console.error("render error");
                let e = {
                    message: error.message,
                    name: error.name,
                    stack: error.stack,
                    properties: error.properties,
                }
                console.log(JSON.stringify({ error: e }));
                throw error;
            }
            let buf = doc.getZip()
                .generate({ type: 'nodebuffer' }) as Buffer;
            response.setHeader("Content-Type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            response.setHeader("Content-Disposition", "attachment; filename=\"calendar.docx\"");
            response.setHeader("Content-Length", buf.length.toString());
            response.write(buf);
            response.end();
        }
        catch (e) {
            response.status(500);
        }
    }
}