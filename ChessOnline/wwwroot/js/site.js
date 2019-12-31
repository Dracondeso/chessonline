$(document).ready(function () {
    console.log('ok funziona');
    chessInitialize();
    console.log("siamo prima dell'onclick")

    $(".clicable").click(function () {
        cleaner();
        pieceChoser(this.classList[3], this.id);
    });

});
var enPassant = '0';
function chessInitialize() {
    $("#1-1").addClass("White WhiteRook clicable");
    $("#1-2").addClass("White WhiteKnight clicable")
    $("#1-3").addClass("White WhiteBishop clicable");
    $("#1-4").addClass("White WhiteQueen clicable");
    $("#1-5").addClass("White WhiteKing clicable");
    $("#1-6").addClass("White WhiteBishop clicable");
    $("#1-7").addClass("White WhiteKnight clicable");
    $("#1-8").addClass("White WhiteRook clicable");
    $("#2-1").addClass("White WhitePawn clicable");
    $("#2-2").addClass("White WhitePawn clicable");
    $("#2-3").addClass("White WhitePawn clicable");
    $("#2-4").addClass("White WhitePawn clicable");
    $("#2-5").addClass("White WhitePawn clicable");
    $("#2-6").addClass("White WhitePawn clicable");
    $("#2-7").addClass("White WhitePawn clicable");
    $("#2-8").addClass("White WhitePawn clicable");
    $("#7-1").addClass("Black BlackPawn clicable");
    $("#7-2").addClass("Black BlackPawn clicable");
    $("#7-3").addClass("Black BlackPawn clicable");
    $("#7-4").addClass("Black BlackPawn clicable");
    $("#7-5").addClass("Black BlackPawn clicable");
    $("#7-6").addClass("Black BlackPawn clicable");
    $("#7-7").addClass("Black BlackPawn clicable");
    $("#7-8").addClass("Black BlackPawn clicable");
    $("#8-1").addClass("Black BlackRook clicable");
    $("#8-2").addClass("Black BlackKnight clicable");
    $("#8-3").addClass("Black BlackBishop clicable");
    $("#8-4").addClass("Black BlackQueen clicable");
    $("#8-5").addClass("Black BlackKing clicable");
    $("#8-6").addClass("Black BlackBishop clicable");
    $("#8-7").addClass("Black BlackKnight clicable");
    $("#8-8").addClass("Black BlackRook clicable");

}
function pawnMove(_id) {
    console.log(_id);
    $("#" + _id).removeClass("clicable");
    $("#" + _id).addClass("clicked");
    var position = _id.split("-");
    if ($("#" + _id).hasClass("White")) {
        var sign = '+'
        var start = 2;
    }
    if ($("#" + _id).hasClass("Black")) {
        var sign = '-';
        var start = 7;
    }
    switch (sign) {
        case "+":
            var check1 = (parseInt(position[0]) + 2) + "-" + (parseInt(position[1]));
            var check2 = (parseInt(position[0]) + 1) + "-" + (parseInt(position[1]));
            var check3 = (parseInt(position[0]) + 1) + "-" + (parseInt(position[1]) - 1);
            var check4 = (parseInt(position[0]) + 1) + "-" + (parseInt(position[1]) + 1);
            sign = "Black";
            console.log("pezzo bianco");
            break;
        case "-":
            var check1 = (parseInt(position[0]) - 2) + "-" + (parseInt(position[1]));
            var check2 = (parseInt(position[0]) - 1) + "-" + (parseInt(position[1]));
            var check3 = (parseInt(position[0]) - 1) + "-" + (parseInt(position[1]) - 1);
            var check4 = (parseInt(position[0]) - 1) + "-" + (parseInt(position[1]) + 1);
            sign = "White";
            console.log("pezzo nero");
            break;
        default:
            break;
    }
    if (!$("#" + check2).hasClass("clicable")) {
        $("#" + check2).addClass("movable");
        $(".movable").click(function () {
            move(_id, check2);
        });
    }
    if ($("#" + check3).hasClass('clicable ,sign')) {
        $("#" + check3).addClass("movable");
        console.log(check3);
        $(".movable").click(function () {
            move(_id, check3);
        });
    }

    if ($("#" + check4).hasClass('clicable ,sign')) {
        $("#" + check4).addClass("movable");
        console.log(check4);
        $(".movable").click(function () {
            move(this.id, check4);
        });
    }

    if (position[0] == start) {
        if (!$("#" + check1).hasClass($('clicable'))) {
            $("#" + check1).addClass("movable");
            $(".movable").click(function () {
                move(this.id, check1);
            });
        }
    }
}
function pieceChoser(data, _id) {
    switch (data) {
        case 'BlackPawn':
            pawnMove(_id);
            break;
        case 'WhitePawn':
            pawnMove(_id);
            break;
        case 'WhiteBishop':
            bishopMove();
            break;
        case 'BlackBishop':
            bishopMove();
            break;
        case 'WhiteKnight':
            knightMove();
        case 'BlackKnight':
            knightMove();
            break;
        case 'WhiteRook':
            rookMove();
            break;
        case 'BlackRook':
            rookMove();
            break;
        case 'WhiteQueen':
            queenMove();
            break;
        case 'BlackQueen':
            queenMove();
            break;
        case 'WhiteKing':
            kingMove();
            break;
        case 'BlackKing':
            kingMove();
            break;
        default:
            break;
    }
}
function cleaner() {
    for (var i = 8; i > 0; i--) {
        for (var j = 1; j < 9; j++) {
            var position = i + "-" + j
            if ($("#" + position).hasClass("clicked")) {
                $("#" + position).removeClass("clicked");
                $("#" + position).addClass("clicable");
            }
            if ($("#" + position).hasClass("movable")) {
                $("#" + position).removeClass("movable");
            }
        }
    }
}
function move(_id, check) {
    var all = ("movable")
    console.log($("#" + _id));
    var classe2 = ($("#" + _id).classList);
    var classe3 = ($("#" + _id).classList);
    console.log(classe2[2]);
    console.log(classe3[3]);
    $("#" + check).removeClass(all)
    $("#" + check).classList[3].removeClass()
    $("#" + _id).classList[2].removeClass()
    $("#" + check).classList[3].removeClass()
        = $("#" + _id).classList[2];
    console.log($("#" + check).classList[0]);
    $("#" + check).classList[3] = $("#" + _id).classList[3];
    $("#" + check).removeClass(classList[4], classList[5]);
    $("#" + _id).removeClass(classList[5], classList[5]);
    $("#" + check).addClass("clicable");
}