class Pitch {
    constructor(w, h, x, y){
        this.w = w;
        this.h = h;
        this.centerX = x;
        this.centerY = y;
        
        // top left x-y (min coords), then bottom right x-y (max coords)
        this.bounds = new Bounds(x - w/2, y - h/2, x + w/2, y + h/2);
    }

    render(){
        strokeWeight(5);
        stroke(255);

        // pitch
        fill(0,200,0);
        rect(this.centerX, this.centerY, this.w, this.h);
        
        // center circle
        ellipse(this.centerX, this.centerY, this.h/3);

        // center line
        line(this.centerX, this.bounds.y1, this.centerX, this.bounds.y2);

        // goal box left
        rect(this.bounds.x1 + this.w / 12, this.centerY, this.w / 6, this.h / 2);
        rect(this.bounds.x1 + this.w/30, this.centerY, this.w / 15, this.h / 5);

        // goal box right
        rect(this.bounds.x2 - this.w/12, this.centerY, this.w/6, this.h/2);
        rect(this.bounds.x2 - this.w/30, this.centerY, this.w/15, this.h/5);

        strokeWeight(0);
    }

}

class Bounds{
    constructor(x1, y1, x2, y2){
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    max_bounds(){
        return [x2, y2];
    }

    min_bounds(){
        return [x1, y1];
    }
}