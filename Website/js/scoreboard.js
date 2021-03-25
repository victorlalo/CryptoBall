class Scoreboard{
    constructor(){
        this.score = [0,0];
        this.time = 0;
        this.game_speed = 1;

        this.halftime = false;
        this.gameover = false;

        this.height = 80;
        this.posY = 65;
    }

    render(){
        fill(100);
        rect(windowWidth/2, this.posY, windowWidth*.35, this.height, 25);
        fill(255,0,0);
        rect(windowWidth*.35, this.posY, windowWidth*.075, this.height + 5, 25);
        fill(0,0,255);
        rect(windowWidth*.65, this.posY, windowWidth*.075, this.height + 5, 25);
        fill(75);
        rect(windowWidth*.5, this.posY, windowWidth*.15, this.height + 15, 25);

        textSize(70);
        textAlign(CENTER);
        fill(255);
        // team scores
        text(this.score[0].toString(), windowWidth*.35, this.posY + 25);
        text(this.score[1].toString(), windowWidth*.65, this.posY + 25);
        
        // timer
        textSize(75);
        //text(this.time.toString(), windowWidth/2, this.posY + 40);
        let timeTextMin = int(this.time / 60).toString();
        let timeTextSec = int(this.time % 60).toString();
        if (timeTextMin.length < 2){
            timeTextMin = "0"+timeTextMin;
        }
        if (timeTextSec.length < 2){
            timeTextSec = "0"+timeTextSec;
        }

        text(timeTextMin + ":" + timeTextSec, windowWidth/2, this.posY + 30);
    }

    updateScore(team){
        this.score[team] += 1;
    }

    update(){
        this.time += this.game_speed * deltaTime/1000;

        if (this.time > 45 && !this.halftime){
            this.halftime = true;
        }
        if (this.time > 90){
            this.gameover = true;
        }
    }
}