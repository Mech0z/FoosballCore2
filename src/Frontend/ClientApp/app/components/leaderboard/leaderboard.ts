import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { LeaderboardView } from '../interfaces/interfaces';

@inject(HttpClient)
export class Leaderboard {
    public leaderboards: LeaderboardView[];
    public selectedLeaderboard: LeaderboardView;

    constructor(http: HttpClient) {
        http.fetch('http://staging-foosball9000api.sovs.net/api/leaderboard/index')
            .then(result => result.json() as Promise<LeaderboardView[]>)
            .then(data => {
                this.leaderboards = data;
                this.selectedLeaderboard = this.leaderboards[0];
            });
    }
}