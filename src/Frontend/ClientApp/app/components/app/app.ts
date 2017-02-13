import { Aurelia } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Aurelia';
        config.map([{
            route: [ '', 'home' ],
            name: 'home',
            settings: { icon: 'home' },
            moduleId: '../home/home',
            nav: true,
            title: 'Home'
        }, {
            route: 'counter',
            name: 'counter',
            settings: { icon: 'education' },
            moduleId: '../counter/counter',
            nav: true,
            title: 'Counter'
        }, {
            route: 'leaderboard',
            name: 'leaderboard',
            settings: { icon: 'th-list' },
            moduleId: '../leaderboard/leaderboard',
            nav: true,
            title: 'Leaderboard'
        }, {
            route: 'fetch-data',
            name: 'fetchdata',
            settings: { icon: 'th-list' },
            moduleId: '../fetchdata/fetchdata',
            nav: true,
            title: 'Fetch data'
        }, {
            route: 'player',
            name: 'player',
            settings: { icon: 'th-list' },
            moduleId: '../player/player',
            nav: false,
            title: 'player'
        }]);

        this.router = router;
    }
}
