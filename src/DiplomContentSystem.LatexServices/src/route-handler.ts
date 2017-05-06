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

            //Load the docx file as a binary
            console.log("init convert docx");
            let content = fs
                .readFileSync(path.resolve(__dirname,"..","templates", "docx", 'calendar.docx'), 'binary');
                console.log("");
            console.log(content);
            let zip = new JSZip(content);
            let doc = new Docxtemplater();
            doc.loadZip(zip);
            const data = {
                stages: [
                    {
                        id: 1,
                        name: "Первый этап",
                        startDate: 1,
                        endDate: 1
                    },
                    {
                        id: 2,
                        name: "Второй этап",
                        startDate: 3,
                        endDate: 2
                    },
                    {
                        id: 3,
                        name: "Третий этап",
                        startDate: 2,
                        endDate: 3
                    }
                ],
                teacher: "Иванов И.А",
                student: "Юндин А.В."
            }
            //const data = JSON.parse(request.body.data.toString());
            doc.setData(data);
            try {
                console.log("now render");
                // render the document (replace all occurences of {first_name} by John, {last_name} by Doe, ...)
                doc.render()
            }
            catch (error) {
                console.log("render error");
                var e = {
                    message: error.message,
                    name: error.name,
                    stack: error.stack,
                    properties: error.properties,
                }
                console.log(JSON.stringify({ error: e }));
                // The error thrown here contains additional information when logged with JSON.stringify (it contains a property object).
                throw error;
            }
            let buf = doc.getZip()
                .generate({ type: 'nodebuffer' }) as Buffer;

            console.log(buf);
            // buf is a nodejs buffer, you can either write it to a file or do anything else with it.
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