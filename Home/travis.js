var travis = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}

};
travis.moduleOptions = {
    APPNAME: "SabioApp"
        , extraModuleDependencies: []
        , runners: []
        , page: travis.page//we need this object here for later use
}


travis.layout.startUp = function () {

    console.debug("travis.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (travis.page.startUp) {
        console.debug("travis.page.startUp");
        travis.page.startUp();
    }

};
travis.APPNAME = "App";//legacy




$(document).ready(travis.layout.startUp);