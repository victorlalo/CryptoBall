
class Ball{
    constructor(spriteDir){
        this.posX = width/2 - BALL_SIZE/2;
        this.posY = height/2 - BALL_SIZE/2;
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