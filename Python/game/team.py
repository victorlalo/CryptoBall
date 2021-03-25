class TeamBrain:
    def __init__(self, team):
        self.players = []

    def update(self):
        for player in self.players:
            player.update()

            if player.scored:
                

