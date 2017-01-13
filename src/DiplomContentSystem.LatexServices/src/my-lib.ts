import { readFileSync } from 'fs';
import { join } from 'path';

export function getPackageVersion() {
  const cwd = process.cwd();
  const rawPkg = readFileSync(join(cwd, 'package.json')).toString();
  const pkg = JSON.parse(rawPkg);

  return pkg.version || 'no version';
}

export function getSample():string {
  const cwd = process.cwd();
  const rawPkg = readFileSync(join(cwd, 'sample.tex')).toString();
  return rawPkg;
}