let pitch;
let redTeam = [];
let blueTeam = [];
let ball;
let scoreboard;
let newscaster;

const PLAYER_SIZE = 20;
const BALL_SIZE = 20;
const PITCH_WIDTH = 600;
const PITCH_HEIGHT = 325;

function setup() {
  createCanvas(windowWidth, windowHeight);
  ellipseMode(CENTER);
  rectMode(CENTER);

  scoreboard = new Scoreboard();
  pitch = new Pitch(PITCH_WIDTH, PITCH_HEIGHT, windowWidth/2, scoreboard.height + 60 + PITCH_HEIGHT/2);
  newscaster = new Newscaster();
  //frameRate(2);

  redTeam.push(new Player(PITCH_WIDTH*.08, PITCH_HEIGHT/2, PLAYER_SIZE, 'red', 'keeper', 0, 0, 1, 0));
  redTeam.push(new Player(PITCH_WIDTH*.29, PITCH_HEIGHT*.7, PLAYER_SIZE, 'red', 'def', 0, 0, 4, 0));
  redTeam.push(new Player(PITCH_WIDTH*.34, PITCH_HEIGHT*.27, PLAYER_SIZE, 'red', 'def', 0, 0, 2, 0));
  redTeam.push(new Player(PITCH_WIDTH*.45, PITCH_HEIGHT*.45, PLAYER_SIZE, 'red', 'striker', 0, 0, 6, 0));
  redTeam.push(new Player(PITCH_WIDTH*.55, PITCH_HEIGHT*.67, PLAYER_SIZE, 'red', 'striker', 0, 0, 4, 0));

  blueTeam.push(new Player(PITCH_WIDTH*.93, PITCH_HEIGHT*.5, PLAYER_SIZE, 'blue', 'keeper', 0, 0, 1, 0));
  blueTeam.push(new Player(PITCH_WIDTH*.75, PITCH_HEIGHT*.35, PLAYER_SIZE, 'blue', 'def', 0, 0, 3, 0));
  blueTeam.push(new Player(PITCH_WIDTH*.76, PITCH_HEIGHT*.7, PLAYER_SIZE, 'blue', 'def', 0, 0, 4, 0));
  blueTeam.push(new Player(PITCH_WIDTH*.65, PITCH_HEIGHT*.45, PLAYER_SIZE, 'blue', 'striker', 0, 0, 6, 0));
  blueTeam.push(new Player(PITCH_WIDTH*.62, PITCH_HEIGHT*.75, PLAYER_SIZE, 'blue', 'striker', 0, 0, 7, 0));

  ball = new Ball('images/ball.png', PITCH_WIDTH/2, PITCH_HEIGHT/2);
  
}

function draw() {
  background(60);
  render();
  update();
}

// call all render functions from here
function render(){
  pitch.render();
  ball.render();
  scoreboard.render();
  newscaster.render();


  redTeam.forEach(player => player.render());
  blueTeam.forEach(player => player.render());
}

// call all update functions from here
function update(){
  redTeam.forEach(player => player.update());
  blueTeam.forEach(player => player.update());

}