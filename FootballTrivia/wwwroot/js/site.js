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
var answers = window.answers;
var points = 0;
var correctCountdown = document.getElementById('correct-countdown');

speedAnswerInput.addEventListener('keyup', function () {
	var answer = this.value;
	if (answers.includes(answer.toLowerCase())) {
		correctCountdown.style.display = 'block';
		startCountdown();
		this.value = "";
		var index = answers.indexOf(answer);
		if (index > -1) {
			answers.splice(index, 1);
			console.log(answers)
		}
	}
});

startGameBtn.addEventListener('click', function () {
	speedAnswerInput.style.display = 'block';
	this.style.display = 'none';
});

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