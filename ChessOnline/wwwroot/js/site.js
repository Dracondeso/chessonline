var start;
var check;
$(document).ready(function () {
    chessInitialize();

    $(".chess").click(function () {
        if ($("#" + this.id).hasClass("clicable")) {
            cleaner();
            start = this.id;
            pieceChosen(start);
            console.log("primo giro");
        }
        if ($("#" + this.id).hasClass("movable")) {
            check = this.id;
            move(start, check);
            console.log("secondo giro");
            start = check;
        }
    });
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


} //Place the chess pieces on board
function north(start) {
    var position = start.split("-");
    var j = 8 - (parseInt(position[0]));
    if ($("#" + start).hasClass("WhitePawn") || $("#" + start).hasClass("WhiteKing BlackKing")) {
        j = 2;
    }
    if ($("#" + start).hasClass("WhitePawn firstMove")) {
        j = 3;
    }
    for (i = 1; i < (j); i++) {
        var check = (parseInt(position[0]) + i) + "-" + (parseInt(position[1]));
        if ($("#" + check).hasClass("clicable")) {
            i = 8;
        }
        console.log(check, start)
        statAssigner(check, start);
    }
} function south(start) {
    var position = start.split("-");
    var j = (parseInt(position[0]));
    if ($("#" + start).hasClass("BlackPawn") || $("#" + start).hasClass("WhiteKing, BlackKing")) {

        j = 6;

    }
    if ($("#" + start).hasClass("WhitePawn, firstMove")) {
        j = 5;

    }

    for (i = 8; i > (j); i--) {
        var check = (j - (8 - i)) + "-" + (parseInt(position[1]));
        if ($("#" + check).hasClass("clicable")) {
            i = j;
        }
        statAssigner(check, start);
    }

}//find box to south
function pawnMove(start) {
    if ($("#" + start).hasClass("White")) {
        north(start);
    }
    else {
        south(start);
    }
}//Rule for pawn move
function bishopMove(start) {
    northEast(start);
    northWest(start);
    southEast(start);
    southWest(start);
}//Rule for bnishop move
function rookMove(start) {
        north(start);
      //  south(start);
}//Rule for rook move
function knightMove(start) {
    var position = start.split('-');
    statAssigner(((parseInt(position[0]) + 1) + "-" + (parseInt(position[1]) + 2)), start);
    statAssigner(((parseInt(position[0]) + 2) + "-" + (parseInt(position[1]) + 1)), start);
    statAssigner(((parseInt(position[0]) + 1) + "-" + (parseInt(position[1]) - 2)), start);
    statAssigner(((parseInt(position[0]) + 2) + "-" + (parseInt(position[1]) - 1)), start);
    statAssigner(((parseInt(position[0]) - 1) + "-" + (parseInt(position[1]) - 2)), start);
    statAssigner(((parseInt(position[0]) - 2) + "-" + (parseInt(position[1]) - 1)), start);
    statAssigner(((parseInt(position[0]) - 1) + "-" + (parseInt(position[1]) + 2)), start);
    statAssigner(((parseInt(position[0]) - 2) + "-" + (parseInt(position[1]) + 1)), start);

}//Rule for knight move
function queenMove(start) {
    bishopMove(start)
    rookMove(start)
}//Rule for queen move
function kingMove(start) {
    queenMove(start)
    castlingMove(start)
}//Rule for king move
function pieceChosen(start) {
    $("#" + start).removeClass("clicable");
    $("#" + start).addClass("clicked");

    var pieceType = $("#" + start)[0].classList[3]
    switch (pieceType) {
        case 'BlackPawn':
            pawnMove(start);
            break;
        case 'WhitePawn':
            pawnMove(start);
            break;
        case 'WhiteBishop':

            bishopMove(start);
            break;
        case 'BlackBishop':
            bishopMove(start);
            break;
        case 'WhiteKnight':
            knightMove(start);
        case 'BlackKnight':
            knightMove(start);
            break;
        case 'WhiteRook':
            rookMove(start);
            break;
        case 'BlackRook':
            rookMove(start);
            break;
        case 'WhiteQueen':
            queenMove(start);
            break;
        case 'BlackQueen':
            queenMove(start);
            break;
        case 'WhiteKing':
            kingMove(start);
            break;
        case 'BlackKing':
            kingMove(start);
            break;
        default:
            break;
    }
}//find the piece on box clicked
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
}//clean assigned class
function move(start, check) {
    const clean = ['firstMove', 'movable', 'clicked', 'clicable', 'White', 'Black', 'WhitePawn', 'BlackPawn', 'WhiteBishop', 'BlackBishop', 'WhiteKnight', 'BlackKnight', 'WhiteRook', 'BlackRook', 'WhiteQueen', 'BlackQueen', 'WhiteKing', 'BlackKing'];
    var classe2 = $("#" + start)[0].classList[2];
    var classe3 = $("#" + start)[0].classList[3];
    $("#" + check).removeClass(clean);
    $("#" + check).addClass(classe2);
    $("#" + check).addClass(classe3);
    $("#" + check).addClass('clicable');
    $("#" + start).removeClass(clean);
    cleaner();

}//assign and remove classes for movement
function statAssigner(check, start) {
    var temp = start.split("-")
    if ((0 < temp[0] < 8) && (0 < temp[1] < 8)) {
        if (!(($("#" + check).hasClass("clicable")) && ($("#" + start)[0].classList[3] == "WhitePawn , BlackPawn"))) {
            if (!($("#" + check).hasClass("clicable"))) {
                $("#" + check).addClass("movable");
            }
            if (($("#" + check).hasClass("clicable")) && ($("#" + check)[0].classList[2] != $("#" + start)[0].classList[2])) {
                $("#" + check).removeClass("clicable");
                $("#" + check).addClass("eatable");
            }
        }
    }
}//assign if is movable or eatable
