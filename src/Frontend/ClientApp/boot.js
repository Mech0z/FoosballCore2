import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap';
// The value is supplied by Webpack during the build
export function configure(aurelia) {
    aurelia.use.standardConfiguration();
    if (IS_DEV_BUILD) {
        aurelia.use.developmentLogging();
    }
    aurelia.start().then(() => aurelia.setRoot('app/components/app/app'));
}
//# sourceMappingURL=boot.js.map