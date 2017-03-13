import { Stream } from "stream";
const latex = require("latex");
export class Converter {
    public convert(source: string | string[]): Stream {
        try {
            return latex(source) as Stream;
        } catch (e) {
            throw new Error("something bad with latex.")
        }
    }
}