
class Ball{
    constructor(spriteDir, x, y){
        this.posX = pitch.bounds.x1 + x - BALL_SIZE/2;
        this.posY = pitch.bounds.y1 + y - BALL_SIZE/2;
        this.possessor = null;
        this.sprite = loadImage(spriteDir);
    }

    render(){
        image(this.sprite, this.posX, this.posY, BALL_SIZE, BALL_SIZE);
    }

    update(){
        
    }

    movePos(x, y){
        this.posX = x;
        this.posY = y;

        // this.update();
    }
}