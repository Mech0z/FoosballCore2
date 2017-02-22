export class App {
    configureRouter(config, router) {
        config.title = 'Aurelia';
        config.map([{
                route: ['', 'home'],
                name: 'home',
                settings: { icon: 'home' },
                moduleId: '../home/home',
                nav: true,
                title: 'Home'
            }, {
                route: 'user',
                name: 'user',
                settings: { icon: 'th-list' },
                moduleId: '../user/user',
                nav: true,
                title: 'User'
            }, {
                route: 'leaderboard',
                name: 'leaderboard',
                settings: { icon: 'th-list' },
                moduleId: '../leaderboard/leaderboard',
                nav: true,
                title: 'Leaderboard'
            }, {
                route: 'playerdetails',
                name: 'playerdetails',
                settings: { icon: 'th-list' },
                moduleId: '../playerdetails/playerdetails',
                nav: false,
                title: 'playerdetails'
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
//# sourceMappingURL=app.js.map