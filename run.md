# Сборка и запуск
Все команды в папке с указанным проектом либо в папке DiplomContentSystem.

## Нужно поставить
* Node.JS >6.7
* .NET Core 1.1
* TexLive

## Глобальные зависимости
* `npm install -g typescript` - ставит TypeScript
* `npm install -g webpack` - ставит Webpack

## Сборка серверной части

### DiplomContentSystem (.NET Core)

Используется как основной сервер нашего приложения. Реализует наше API.

* `cd <Folder>` - переход к нашей папке
* `dotnet restore` - установка зависимостей и NuGet-пакетов, указанных в `project.json` каждого проекта.
* `dotnet run` - запуск приложения. При запуске из студии или Code вызывается автоматически
* `set ASPNETCORE_ENVIRONMENT=Development` - устанавливает нужный флаг для включения Hot Module Replacement

### LatexServices (Node.JS+Express)

Дополнительный сервер, который используется для обработки *.tex* -файлов.

В Visual Studio Code настроены средства по сборке.
* `npm install` - установка зависимостей.
* `Ctrl+Shift+B` - сборка нашего проекта из Typescript в Javascript. (По сути вызывает компилятор tsc)
* `node .` - запуск сервера.

## Сборка клиентской части
* `npm install` - установка зависимостей.
* `webpack`  - сбора клиентской части
  * `webpack --env.prod` - сборка минифицированного клиента
* `webpack --config webpack.config.vendor.js`  - сбора зависимостей клиентской части
  * `webpack  --config webpack.config.vendor.js --env.prod` - сборка минифицированных зависимостей клиентской части

