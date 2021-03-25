from constants import *
import math
from random import random


class Player:
    def __init__(self, posX, posY, role, team_brain, speed, accuracy, defense, strength):
        self.position = [posX, posY]
        self.role = role
        self.team_brain = team_brain
        self.has_possession = False

        # ATTRIBUTES
        self.speed = speed
        self.accuracy = accuracy
        self.defense = defense
        self.strength = strength


    def take_action(self):
        if self.role == Role.STRIKER:
            return

        elif self.role == Role.DEFENDER:
            return

        else:
            return

    def check_ball_pos(self):
        return

    def shoot_ball(self):
        # successful shot if random float (0.00 - 1.00) is less than accuracy attribute
        success = random() < self.accuracy
        return success

    def pass_ball(self):
        return

    def block_shot(self):
        return

class Striker(Player):
    def __init__(self, posX, posY, role, team_brain, speed, accuracy, defense, strength):
        super().__init__(posX, posY, role, team_brain, speed, accuracy, defense, strength)

    def take_action(self):
        if self.has_possession:
            if (self.team_brain.team_name == Team.RED and self.position[0] >= 3) or (self.team_brain.team_name == Team.BLUE and self.position[0] <= -3):
                self.shoot_ball()
            elif self.team_brain:
                self.pass_ball()
