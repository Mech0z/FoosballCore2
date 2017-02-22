import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { LeaderboardView } from '../interfaces/interfaces';
import { Player } from '../interfaces/interfaces';

@inject(HttpClient)
export class Leaderboard {
    public leaderboards: LeaderboardView[];
    public selectedLeaderboard: LeaderboardView;
    public Players: Player[];
    public Loading: boolean;

    constructor(http: HttpClient) {
        this.Loading = true;
        http.fetch('http://staging-foosball9000api.sovs.net/api/leaderboard/index')
            .then(result => result.json() as Promise<LeaderboardView[]>)
            .then(data => {
                this.leaderboards = data;
                this.selectedLeaderboard = this.leaderboards[0];
            });

            http.fetch('http://staging-foosball9000api.sovs.net/api/player/GetUsers')
            .then(result => result.json() as Promise<Player[]>)
            .then(data => {
                this.Players = data;
            });
    }        

    GetUser(email: string)
    {
        for (var player of this.Players) {
                if(player.Email == email){
                    return player;
                }
        }
    }
}