class Player{
    constructor(x, y, r, team, role, atk, def, spd, str){
        this.posX = pitch.bounds.x1 + x;
        this.posY = pitch.bounds.y1 + y;

        this.radius = r;
        this.team = team;
        if (team == 'red'){
            this.color = color(255,0,0);
        }
        else{
            this.color = color(0,0,255);
        }

        this.role = role;
        this.atk = atk;
        this.def = def;
        this.spd = spd;
        this.str = str;
    }

    update(){
        //this.move();
    }

    render(){
        fill(this.color);
        strokeWeight(1);
        stroke(0);
        ellipse(this.posX, this.posY, this.radius);
    }

    move(){
        let spdMultiplier = .25;
        this.posX += random(-this.spd, this.spd) * spdMultiplier;
        this.posY += random(-this.spd, this.spd) * spdMultiplier;
    }
}