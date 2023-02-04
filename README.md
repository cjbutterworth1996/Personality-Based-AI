# COMP250 Proposal: Nightmare Labyrinth

## Introduction
This game is a procedurally generated maze which players have to navigate while avoiding enemies. Players will use a pulse monitor that allows the AI director to detect gameplay patterns that result in fluctuations in heartrate. Based on these findings, the AI will alter the generation of the maze and enemy spawning to attempt to increase the player's heartrate. My chosen specialism is artificial intelligence in games programming. This project is in alignment with that specialization because the AI director will use machine learning to optimize procedural generation. This artefact could be used in several different fields. An AI that can recognize emotional arousal states and then effectively respond to influence those states could optimize emotional responses in video games, strengthen lie detector equipment, and optimize anxiety-reduction software among other things.

## Project Outline

The artefact will use reinforcement learning to train an AI to consistently generate higher arousal responses. The artefact will consist of a procedurally generated maze and 3 types of AI controlled enemies. The player will be hooked up to a finger-strap style pulse monitor to let the AI determine the player's heartrate.

The parameters that the AI will be trained to optimize are:
1. How long it should wait between enemy spawns
2. What kind of enemy it should spawn

## Software Architecture

Reinforcement learning trains AI by programming it to maximize a reward function. It is used to "automatically evaluate the optimal behavior in a particular context or environment to improve its efficiency," (Sarker 2021). This makes it an ideal candidate for this project, as it aims to optimize the AI's efficiency of heigtening  the player's heartrate. 

&nbsp;
<img src ="https://media.github.falmouth.ac.uk/user/748/files/08ca57b4-3d0c-4178-800a-787526a2994b">
<p align ="center">Fig. 1 - Guszejnov 2022. The results of an AI learning to play a version of a snake game using reinforcement learning. Graph generated using TensorBoard.</p>

&nbsp;

Given the limited control of the director AI, there will only need to be one key class, GAME, that represents the game variables the AI will interact with. Within the game itself, there will also be a MONSTER class with different subclasses for each monster type, as well as a PLAYER class for the player character.

## Similar Projects

The game developers for *VANISH* (2013) attempted to determine if "biofeedback-enabled adaptive methods have a significant impact on any specific aspect of the players' gameplay experience," (Nogueira et al. 2016).  The study used heartrate, skin conductivity, and facial electromyography to alter game generation. Their study concluded that "biofeedback-augmented gameplay is suitable as both a dramatic enhancer and a regulator of the player experience," (Nogueira et al. 2016).

The biggest issue with this study is that they do not explain why they chose certain physiological inputs to affect specific aspects of gameplay. For example, there is no explanation given for why valence was attached to monster generations instead of arousal.


A study done on physiological controls in gaming claims "most examples of prior research on physiologically-
controlled games use indirect control," and "these games demonstrate how physiological input is not directly controlled, but mediated by some other player interaction, such as meditation or deep breathing," (Nacke et al. 2011).

&nbsp;
<img src ="https://media.github.falmouth.ac.uk/user/748/files/73d443a0-2307-49f4-9eca-07f016ff8092">
<p align ="center">Fig. 2 - <i>Mindball Play</i> 2018. A game that uses an EEG headband to control a ball using brainwave-determined "focus."</p>
  
&nbsp;

In another study on the use of biofeedback in games to learn paced breathing, the authors found that biofeedback augmentation "led to better breath control during play," proving that biofeedback augmented gaming can successfully influence biofeedback metrics, at least in a calming manner (Zafar 2020). Conversely, this artefact will attempt to prove that AI using biofeedback is also capable of inducing higher arousal states in the player.
 
&nbsp;
<img src ="https://media.github.falmouth.ac.uk/user/748/files/fb89f6b1-958e-4713-b016-30755c738eb5">
<p align ="center">Fig. 3 - <i>DEEP VR</i> 2021. A game that teaches controlled breathing techniques and helps to relieve anxiety using a biofeedback-enabled diagphragm band
    that senses player's breathing.</p>

  
&nbsp;
## Production Timeline

There are six weeks of production time pending the approval of this proposal. Using AGILE as a development life cycle model, the first week will consist of research and planning the software's architecture. Weeks two through four will be spent developing and testing the software using user feedback along the way to optimize the experience. Weeks five and six will consist of training the AI and polishing to assure the AI has enough training time to produce meaningful results. The AI will be completed as soon as possible with the game world and game elements following thereafter.

## Scope Feasibility
This artefact will use PyTorch, which provides "scalable distributed training and performance optimization in research and production," and integrates directly into Unity (PyTorch). Additionally, I will be using a standardized library that uses PyTorch called Stable-Baselines3, which is "a set of reliable implementations of reinforcement learning algorithms in PyTorch," (Stable-Baselines3 2022). Using these two tools will allow me to produce an effective AI using reinforcement learning within the time scope of this project.

## Research Methods

Using practice-based research, this artefact will determine if the AI is more effective at producing a higher arousal response in players than a similar, scripted experience. This research will determine output effectiveness primarily and objectively via heartrate fluctuations as well as secondarily and subjectively via player questionnaires. Additional testing methods such as an increased number of physiological inputs, simulations of different types of fear, and varying recognition pattern testing would all increase the relevancy and validity of the project's data, but fall outside the current scope due to time limitations.

# Bibliography

GAMEJOLT. 2014.'VANISH by 3DrunkMen'. Available at: https://gamejolt.com/games/vanish/29440 [accessed 2 February 2023].

NACKE, Lennart, Michael KALYN, Calvin LOUGH and Regan MANDRYK. 2011. 'Biofeedback Game Design: Using Direct and Indirect Physiological Control to Enhance Game Interaction'. Paper presented at the internation conference on *Human Factors in Computing Systems*. Vancouver, Canada, 7-12 May 2011. Available at: https://www.researchgate.net/publication/221518632_Biofeedback_Game_Design_Using_Direct_and_Indirect_Physiological_Control_to_Enhance_Game_Interaction [accessed 2 February 2013].

NOGUEIRA, Pedro A., Torres VASCO, Rui RODRIGUES, Eugénio OLIVEIRA and Lennart E. NACKE. 2016. 'Vanishing scares: biofeedback modulation of affective player experiences in a procedural horror game'. *Journal on Multimodal User Interfaces*, 10, 31-62.

PYTORCH. 'Home page'. Available at: https://pytorch.org/ [accessed 2 February 2023].

SARKER, I.H. 2021. 'Machine Learning: Algorithms, Real-World Applications and Research Directions'. *SN Computer Science*, 2(160).

STABLE-BASELINES3. 'Stable-Baselines3 Docs - Reliable Reinforcement Learning Implementations'. Available at: https://stable-baselines3.readthedocs.io/en/master/ [accessed 2 February 2023].

*VANISH*. 2014. 3DrunkMen, 3DrunkMen.

ZAFAR, M. Abdullah, Beena AHMED, Rami Al RIHAWI and Ricardo GUTIERREZ-OSUNA. 2020. 'Gaming Away Stress: Using Biofeedback Games to Learn Paced Breathing". *IEEE Transactions on Affective Computing*, 11(3), 519-531.

# Appendix - Figures

Figure 1. GUSZEJNOV, Dávid. 2022. 'How to Train an AI to Play Any Game'. *Towards Data Science* [online]. Available at: https://towardsdatascience.com/how-to-train-an-ai-to-play-any-game-f1489f3bc5c [accessed 4 February 2023].

Figure 2. *Mindball Play*. 2018. Mentalytics Team, Mentalytics AB.

Figure 3. *DEEP VR*. 2021. Explore DEEP, Explore DEEP.
