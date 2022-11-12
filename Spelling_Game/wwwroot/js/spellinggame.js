window.onload = function () {
    initListener();
}

function initListener() {
    // setup each node to listen to a mouse-click
    let node = document.getElementById("submit_answer_button");
    node.addEventListener('click', checkAnswer);

}

function testfunction(stuff) {
    if (stuff.value.length == 1) {
        document.getElementById(parseInt(stuff.id) + 1).focus();
    }
}

function checkAnswer() {
    var player_answer = "";
    var answer = document.getElementById("answer_form").getAttribute("answer").toLowerCase();
    var answer_nodes = document.getElementById("answer_form").children;
    for (var i = 0; i < answer_nodes.length; i++) {
        player_answer = player_answer + answer_nodes[i].value.toLowerCase()       
    }
    console.log(player_answer);
    console.log(answer);
    if (answer == player_answer) {
        alert("Excellent job!");
    }
    else {
        alert("Try again!!!");
    }
}