//# region Answer round logic
// WIP: Quiz section of game needs implementing
//var questions = window.questions;
//var currentQuestion = 0;

//document.getElementById('question').innerHTML = questions[currentQuestion][0]

//var correctAnswer = questions[currentQuestion][1][0]
//var answers = questions[currentQuestion][1]
//var randomisedAnswers = answers.sort(() => Math.random() - 0.5)

//var answer0 = document.getElementById('answer-0')
//var answer1 = document.getElementById('answer-1')
//var answer2 = document.getElementById('answer-2')

//answer0.innerHTML = randomisedAnswers[0]
//answer1.innerHTML = randomisedAnswers[1]
//answer2.innerHTML = randomisedAnswers[2]

//var elemList = [answer0, answer1, answer2]

//function checkAnswer(element) {
//	var answerCheck = document.getElementById('answer-check')
//	var green = '#12c712'
//	var red = '#ff0000'

//	var answer = element.innerHTML
//	if (answer == correctAnswer) {
//		answerCheck.innerHTML = "That's correct!"
//		answerCheck.style.color = green
//	} else {
//		answerCheck.innerHTML = "That's incorrect!"
//		answerCheck.style.color = red
//	}
//	answerCheck.style.display = 'block'
//	isCorrect(elemList)
//}

//function isCorrect(elementList) {
//	elementList.forEach(element => {
//		element.classList.remove('btn-primary')
//		element.onclick = null
//		if (correctAnswer == element.innerHTML) {
//			element.classList.add('btn-success')
//		} else {
//			element.classList.add('btn-danger')
//		}
//    })
//}

var speedAnswerInput = document.getElementById('speed-answer');
var startGameBtn = document.getElementById('start-game');
var restartGameBtn = document.getElementById('restart-game');
var answers = window.answers;
var completeAnswers = answers.slice(); //create a shallow copy of the answers array
var points = 0;
var correctCountdown = document.getElementById('correct-countdown');
var countdownElement = document.getElementById('countdownDisplay');
var pointsElement = document.getElementById('points');
var gameInterval;
var highScoreElement = document.getElementById('high-score');

if (speedAnswerInput !== null) {
    speedAnswerInput.addEventListener('keyup', function () {
        var answer = this.value;
        if (answers.includes(answer.toLowerCase())) {
            correctCountdown.style.display = 'block';
            startCountdown();
            this.value = "";
            var index = answers.indexOf(answer);
            points++;
            pointsElement.textContent = 'Points: ' + points;
            if (index > -1) {
                answers.splice(index, 1);
                console.log(answers);
            }
            if (answers.length === 0) {
                gameWon();
            }
        }
    });
}

if (startGameBtn !== null) {
    startGameBtn.addEventListener('click', function () {
        speedAnswerInput.style.display = 'block';
        this.style.display = 'none';
        gameTimer();
        countdownElement.style.display = 'block';
        pointsElement.style.display = 'block';
    });
}

if (restartGameBtn !== null) {
    restartGameBtn.addEventListener('click', function () {
        points = 0;
        pointsElement.textContent = 'Points: ' + points;
        speedAnswerInput.disabled = false;
        gameTimer();
        answers = completeAnswers.slice();
        restartGameBtn.style.display = 'none';
    });    
}

function startCountdown() {
    var countdownTime = 1;
    var countdownInterval = setInterval(function () {
        countdownTime--;

        if (countdownTime <= 0) {
            clearInterval(countdownInterval);
            correctCountdown.style.display = 'none';
        }
    }, 1000)
}

function gameTimer() {
    var timeRemaining = 60;

    gameInterval = setInterval(function () {
        timeRemaining--;
        countdownElement.textContent = 'Time remaining: ' + timeRemaining + ' seconds';

        if (timeRemaining <= 0) {
            finishGame("Time's up!");
        }
    }, 1000)
}

function gameWon() {
    finishGame('You win!');
}

var quizLinks = document.querySelectorAll('.begin-quiz-link');
var dropdownBtn = document.getElementById('js-dropdown-btn');
function getYear(element) {
    dropdownBtn.textContent = element.textContent;
    quizLinks.forEach(function (e) {
        var year = element.textContent;
        var queryString = '&year=' + year;
        e.href += queryString;
    });
}

function checkScore() {
    var highScore = Number(highScoreElement.innerHTML);
    if (points > highScore) {
        var apiUrl = `/UpdateScore?username=${window.username}&score=${points}`;
        fetch(apiUrl, {
            method: 'PATCH'
        }).then(response => {
            if (response.ok) {
                console.log('SUCCESS!');
            }
            else {
                console.log('FAILURE!');
            }
        });

        highScoreElement.textContent = points;
    }
}

function finishGame(text) {
    clearInterval(gameInterval);
    countdownElement.textContent = text;
    speedAnswerInput.disabled = true;
    checkScore();
    restartGameBtn.style.display = 'block';
}