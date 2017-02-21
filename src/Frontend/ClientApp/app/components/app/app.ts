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
            route: 'leaderboard',
            name: 'leaderboard',
            settings: { icon: 'th-list' },
            moduleId: '../leaderboard/leaderboard',
            nav: true,
            title: 'Leaderboard'
        }, {
            route: 'player',
            name: 'player',
            settings: { icon: 'th-list' },
            moduleId: '../player/player',
            nav: false,
            title: 'player'
        }, {
            route: 'add-match',
            name: 'add-match',
            settings: { icon: 'th-list' },
            moduleId: '../add-match/add-match',
            nav: true,
            title: 'Add match'
        }]);

        this.router = router;
    }
}
