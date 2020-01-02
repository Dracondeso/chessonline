$(document).ready(function () {
    console.log('ok funziona');
    chessInitialize();
    console.log("siamo prima dell'onclick")

    $(".clicable").click(function () {
        cleaner();
        pieceChosen(this.classList[3], this.id);
    })
        ;

});
function chessInitialize() {
    $("#1-1").addClass("White WhiteRook clicable firstMove");
    $("#1-2").addClass("White WhiteKnight clicable firstMove")
    $("#1-3").addClass("White WhiteBishop clicable firstMove");
    $("#1-4").addClass("White WhiteQueen clicable firstMove");
    $("#1-5").addClass("White WhiteKing clicable firstMove");
    $("#1-6").addClass("White WhiteBishop clicable firstMove");
    $("#1-7").addClass("White WhiteKnight clicable firstMove");
    $("#1-8").addClass("White WhiteRook clicable firstMove");
    $("#2-1").addClass("White WhitePawn clicable firstMove");
    $("#2-2").addClass("White WhitePawn clicable firstMove");
    $("#2-3").addClass("White WhitePawn clicable firstMove");
    $("#2-4").addClass("White WhitePawn clicable firstMove");
    $("#2-5").addClass("White WhitePawn clicable firstMove");
    $("#2-6").addClass("White WhitePawn clicable firstMove");
    $("#2-7").addClass("White WhitePawn clicable firstMove");
    $("#2-8").addClass("White WhitePawn clicable firstMove");
    $("#7-1").addClass("Black BlackPawn clicable firstMove");
    $("#7-2").addClass("Black BlackPawn clicable firstMove");
    $("#7-3").addClass("Black BlackPawn clicable firstMove");
    $("#7-4").addClass("Black BlackPawn clicable firstMove");
    $("#7-5").addClass("Black BlackPawn clicable firstMove");
    $("#7-6").addClass("Black BlackPawn clicable firstMove");
    $("#7-7").addClass("Black BlackPawn clicable firstMove");
    $("#7-8").addClass("Black BlackPawn clicable firstMove");
    $("#8-1").addClass("Black BlackRook clicable firstMove");
    $("#8-2").addClass("Black BlackKnight clicable firstMove");
    $("#8-3").addClass("Black BlackBishop clicable firstMove");
    $("#8-4").addClass("Black BlackQueen clicable firstMove");
    $("#8-5").addClass("Black BlackKing clicable firstMove");
    $("#8-6").addClass("Black BlackBishop clicable firstMove");
    $("#8-7").addClass("Black BlackKnight clicable firstMove");
    $("#8-8").addClass("Black BlackRook clicable firstMove");

}
function north(_id) {
    var position = _id.split("-");
    var j = 0;
    if (($("#" + _id).hasClass("WhitePawn")) || ($("#" + _id).hasClass("WhiteKing, BlackKing"))) {
        j = 6;
    }
    if ($("#" + _id).hasClass("WhitePawn, firstMove")) {
        j = 5;
    }

    for (i = j; i < 8; i++) {
            var check = (parseInt(position[0]) + (8 - i)) + "-" + (parseInt(position[1]));
        if (!($("#" + check).hasClass("clicable"))) {
            var pieceType = ($("#" + _id)[0].classList[2]);
            statAssigner(check, pieceType);
            $(".movable").click(function () {
                move(_id, check);
            })
        }
        else {
            if (($("#" + _id)[0].classList[2]) == ($("#" + check)[0].classList[2])) {
                break;
            }
            else {
                statAssigner(check, pieceType);
                $(".movable").click(function () {
                    move(_id, check);
                })
            }
        }
    }
}

            //if (($("#" + check).hasClass("clicable")) && ($("#" + _id)[0].classList[2]) != ($("#" + check)[0].classList[2])) {
            //    console.log("pezzo trovato");
            //    break;
            //    if (($("#" + check).hasClass("clicable")) && $("#" + check)[0].classList[2] == $("#" + _id)[0].classList[2]) {
            //        break
            //    }
            //}
function south(_id) {
    var position = _id.split("-");
    console.log("questo1",position)
    var j = 8;
    if (($("#" + _id).hasClass("BlackPawn")) || ($("#" + _id).hasClass("WhiteKing, BlackKing"))) {
        j = 3;
    }
    console.log("2", j)
    if ($("#" + _id).hasClass("BlackPawn, firstMove")) {
        j = 4;
    }
    for (i = j; i > 0; i--) {
        var check = (parseInt(position[0]) + (8 - i)) + "-" + (parseInt(position[1]));
        if (!($("#" + check).hasClass("clicable"))) {
            var pieceType = ($("#" + _id)[0].classList[2]);
            statAssigner(check, pieceType);
            $(".movable").click(function () {
                move(_id, check);
            console.log(check);
            })
        }
        else {
            if (($("#" + _id)[0].classList[2]) == ($("#" + check)[0].classList[2])) {
                break;
            }
            else {
                statAssigner(check, pieceType);
                $(".movable").click(function () {
                    move(_id, check);
                })
            }
        }
    }
}
function pawnMove(_id) {
    if ($("#" + _id).hasClass("White")) {
        north(_id);
    }
    else {
        south(_id);
        console.log("nero")
    }
    move()
}
function bishopMove(_id) {
    northEast(_id);
    northWest(_id);
    southEast(_id);
    southWest(_id);
}
function rookMove(_id) {
    north(_id);
    east(_id);
    west(_id);
    south(_id);
}
function knightMove(_id) {
    var position = _id.split('-');
    console.log(position)
    statAssigner($("#" + ((position[0] + 1) + "-" + (position[1] + 2))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] + 2) + "-" + (position[1] + 1))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] + 1) + "-" + (position[1] - 2))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] + 2) + "-" + (position[1] - 1))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] - 1) + "-" + (position[1] - 2))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] - 2) + "-" + (position[1] - 1))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] - 1) + "-" + (position[1] + 2))), ($("#" + _id)[0].classList[2]));
    statAssigner($("#" + ((position[0] - 2) + "-" + (position[1] + 1))), ($("#" + _id)[0].classList[2]));

}
function queenMove(_id) {
    bishopMove(_id)
    rookMove(_id)
}
function kingMove(_id) {
    queenMove(_id)
    castlingMove(_id)
}
function pieceChosen(pieceType, _id) {
    $("#" + _id).removeClass("clicable");
    $("#" + _id).addClass("clicked");
    switch (pieceType) {
        case 'BlackPawn':
            pawnMove(_id);
            break;
        case 'WhitePawn':
            pawnMove(_id);
            break;
        case 'WhiteBishop':

            bishopMove(_id);
            break;
        case 'BlackBishop':
            bishopMove(_id);
            break;
        case 'WhiteKnight':
            knightMove(_id);
            console.log("try");
        case 'BlackKnight':
            knightMove(_id);
            break;
        case 'WhiteRook':
            rookMove(_id);
            break;
        case 'BlackRook':
            rookMove(_id);
            break;
        case 'WhiteQueen':
            queenMove(_id);
            break;
        case 'BlackQueen':
            queenMove(_id);
            break;
        case 'WhiteKing':
            kingMove(_id);
            break;
        case 'BlackKing':
            kingMove(_id);
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
            if ($("#" + position).hasClass("eatable")) {
                $("#" + position).removeClass("eatable");
                $("#" + position).addClass("clicable");
            }

        }
    }
}
function move(_id, check) {
    const clean = ['firstMove', 'movable', 'clicked', 'clicable', 'White', 'Black', 'WhitePawn', 'BlackPawn', 'WhiteBishop', 'BlackBishop', 'WhiteKnight', 'BlackKnight', 'WhiteRook', 'BlackRook', 'WhiteQueen', 'BlackQueen', 'WhiteKing', 'BlackKing'];
    var classe2 = $("#" + _id)[0].classList[2];
    var classe3 = $("#" + _id)[0].classList[3];
    $("#" + check).removeClass(clean);
    $("#" + check).addClass(classe2);
    $("#" + check).addClass(classe3);
    $("#" + check).addClass('clicable');
    $("#" + _id).removeClass(clean);
    $("#" + check).addClass('clicable');
    console.log(_id);
    console.log(check);
    console.log(classe2);
    cleaner();
}
function statAssigner(check, side) {
    if (!($("#" + check).hasClass("clicable"))) {
        $("#" + check).addClass("movable");
    }
    if ($("#" + check)[0].classList[2] != side) {
        $("#" + check).removeClass("clicable");
        $("#" + check).addClass("eatable");
    }
}



//function pawnMove(_id) {
//    console.log(_id);
//    $("#" + _id).removeClass("clicable");
//    $("#" + _id).addClass("clicked");
//    var position = _id.split("-");
//    if ($("#" + _id).hasClass("White")) {
//        var sign = '+'
//        var start = 2;
//    }
//    if ($("#" + _id).hasClass("Black")) {
//        var sign = '-';
//        var start = 7;
//    }
//    switch (sign) {
//        case "+":
//            var check1 = (parseInt(position[0]) + 2) + "-" + (parseInt(position[1]));
//            var check2 = (parseInt(position[0]) + 1) + "-" + (parseInt(position[1]));
//            var check3 = (parseInt(position[0]) + 1) + "-" + (parseInt(position[1]) - 1);
//            var check4 = (parseInt(position[0]) + 1) + "-" + (parseInt(position[1]) + 1);
//            sign = "Black";
//            console.log("pezzo bianco");
//            break;
//        case "-":
//            var check1 = (parseInt(position[0]) - 2) + "-" + (parseInt(position[1]));
//            var check2 = (parseInt(position[0]) - 1) + "-" + (parseInt(position[1]));
//            var check3 = (parseInt(position[0]) - 1) + "-" + (parseInt(position[1]) - 1);
//            var check4 = (parseInt(position[0]) - 1) + "-" + (parseInt(position[1]) + 1);
//            sign = "White";
//            console.log("pezzo nero");
//            break;
//        default:
//            break;
//    }
//    if (!$("#" + check2).hasClass("clicable")) {
//        $("#" + check2).addClass("movable");
//        $(".movable").click(function () {
//            check = check2
//        });
//    }
//    if ($("#" + check3).hasClass('clicable ,sign')) {
//        $("#" + check3).addClass("movable");
//        $(".movable").click(function () {
//            check = check3
//        });
//    }

//    if ($("#" + check4).hasClass('clicable ,sign')) {
//        $("#" + check4).addClass("movable");
//        $(".movable").click(function () {
//            check = check4
//        });
//    }

//    if (position[0] == start) {
//        if (!$("#" + check1).hasClass($('clicable'))) {
//            $("#" + check1).addClass("movable");
//            $(".movable").click(function () {
//                check = check1
//            });
//        }
//    }
//    move(_id, check);
//}
