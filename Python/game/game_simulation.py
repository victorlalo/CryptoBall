class Game:
    HALF_TIME = 45
    FULL_TIME = 90

    def __init__(self, game_speed):
        self.score = [0, 0]
        self.game_speed = int(game_speed)
        self.time_elapsed = 0
        self.ball_possessor = None
        self.ball_position = [0,0]
        self.teams = []

    def increment_goal(self, team):
        self.score[team] += 1
        return

    def tick(self):
        self.time_elapsed += 1 * self.game_speed
        return

    def update(self):
        for team in self.teams:
            team.update()
        return
