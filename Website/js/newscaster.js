class Newscaster{
    constructor(){
        this.events = [];
        this.playerStats = [];
        this.height = 400;

    }

    render(){
        rectMode(CORNER);
        fill(100);

        // PLAY BY PLAY
        rect(windowWidth*.12, 500, windowWidth*.45, this.height, 20);

        textSize(30);
        fill(255);

        // TODO: change text below to reading from events array, time, and score
        textAlign(LEFT);
        text("60:21", windowWidth*.12 + 40, 550);
        text("Reapers Score!! GOALLAZO!!", windowWidth*.21, 550);
        textAlign(RIGHT);
        text("2-1", windowWidth*0.54, 550);

        textAlign(LEFT);
        text("56:28", windowWidth*.12 + 40, 600);
        text("Thunders Save!", windowWidth*.21, 600);
        textAlign(RIGHT);
        text("1-1", windowWidth*0.54, 600);

        textAlign(LEFT);
        text("45:00", windowWidth*.12 + 40, 650);
        text("Half Time. Rewire those circuits!", windowWidth*.21, 650);
        textAlign(RIGHT);
        text("1-1", windowWidth*0.54, 650);

        textAlign(LEFT);
        text("39:32", windowWidth*.12 + 40, 700);
        text("Reapers Score! The playfield is even.", windowWidth*.21, 700);
        textAlign(RIGHT);
        text("1-1", windowWidth*0.54, 700);

        textAlign(LEFT);
        text("34:16", windowWidth*.12 + 40, 750);
        text("Thunders Score! The crowd goes wild!", windowWidth*.21, 750);
        textAlign(RIGHT);
        text("0-1", windowWidth*0.54, 750);

        textAlign(LEFT);
        text("21:58", windowWidth*.12 + 40, 800);
        text("Thunders take the shot. It's deflected!", windowWidth*.21, 800);
        textAlign(RIGHT);
        text("0-0", windowWidth*0.54, 800);



        // STATS
        fill(100);
        rect(windowWidth*.58, 500, windowWidth*.25, this.height, 20);
        fill(255);
        
        textAlign(LEFT);
        textStyle(BOLD);
        text("Player", windowWidth*.58 + 30, 550);
        textAlign(CENTER);
        text("GLS", windowWidth*.58 + 200, 550);
        text("AST", windowWidth*.58 + 300, 550);
        text("STL", windowWidth*.58 + 400, 550);

        textSize(24);
        textAlign(LEFT);
        textStyle(NORMAL);
        text("BIGGO", windowWidth*.58 + 30, 625);
        textAlign(CENTER);
        text("1", windowWidth*.58 + 200, 625);
        text("2", windowWidth*.58 + 300, 625);
        text("0", windowWidth*.58 + 400, 625);

        textAlign(LEFT);
        textStyle(NORMAL);
        text("JUIZO", windowWidth*.58 + 30, 675);
        textAlign(CENTER);
        text("1", windowWidth*.58 + 200, 675);
        text("0", windowWidth*.58 + 300, 675);
        text("2", windowWidth*.58 + 400, 675);

        textAlign(LEFT);
        textStyle(NORMAL);
        text("TRONO", windowWidth*.58 + 30, 725);
        textAlign(CENTER);
        text("1", windowWidth*.58 + 200, 725);
        text("0", windowWidth*.58 + 300, 725);
        text("0", windowWidth*.58 + 400, 725);

        textAlign(LEFT);
        textStyle(NORMAL);
        text("TESSLER", windowWidth*.58 + 30, 775);
        textAlign(CENTER);
        text("0", windowWidth*.58 + 200, 775);
        text("2", windowWidth*.58 + 300, 775);
        text("1", windowWidth*.58 + 400, 775);

        textAlign(LEFT);
        textStyle(NORMAL);
        text("PIKRON", windowWidth*.58 + 30, 825);
        textAlign(CENTER);
        text("0", windowWidth*.58 + 200, 825);
        text("1", windowWidth*.58 + 300, 825);
        text("2", windowWidth*.58 + 400, 825);
        

        rectMode(CENTER);
    }

    addNewEvent(eventString){
        this.events.push(eventString);
        // updateStats();
    }

    updateStats(){

    }
}