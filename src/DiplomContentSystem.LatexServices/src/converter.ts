import { Stream } from "stream";
const latex = require("latex");
export class Converter {
    public convert(source: string | string[]): Stream {
        return <Stream>latex(source);
    }
}