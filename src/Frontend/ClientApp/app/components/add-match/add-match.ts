import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { LeaderboardView } from '../interfaces/interfaces';

@inject(HttpClient)
export class AddMatch {
    public leaderboards: LeaderboardView[];
    public activeLeaderboard: LeaderboardView;

    constructor(http: HttpClient)
    {
        http.fetch('http://staging-foosball9000api.sovs.net/api/leaderboard/index')
            .then(result => result.json() as Promise<LeaderboardView[]>)
            .then(data => {
                this.leaderboards = data;
                this.activeLeaderboard = this.leaderboards[0];            
            });
    }
}

