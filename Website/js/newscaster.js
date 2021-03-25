class Newscaster{
    constructor(){
        this.events = [];
        this.height = 400;

    }

    render(){
        fill(100);
        rect(windowWidth*.375, 700, windowWidth*.45, this.height, 20);
        rect(windowWidth*.75, 700, windowWidth*.25, this.height, 20);
    }

    addNewEvent(){

    }
}