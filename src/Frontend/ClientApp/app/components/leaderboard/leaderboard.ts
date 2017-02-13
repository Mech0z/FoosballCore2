import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(HttpClient)
export class Leaderboard {
    public leaderboards: LeaderboardView[];
    public selectedLeaderboard: LeaderboardView;

    constructor(http: HttpClient) {
        http.fetch('http://staging-foosball9000api.sovs.net/api/leaderboard/index')
            .then(result => result.json() as Promise<LeaderboardView[]>)
            .then(data => {
                this.leaderboards = data;
                this.selectedLeaderboard = this.leaderboards[1];
            });
    }
}

interface LeaderboardView {
    SeasonName: string;
    Timestamp: string;
    Entries: Array<LeaderboardViewEntry>;
}

interface LeaderboardViewEntry{
    EloRating: number;
    Form: string;
    NumberOfGames: number;
    Wins: number;
    Losses: number;
    UserName: string;
}
