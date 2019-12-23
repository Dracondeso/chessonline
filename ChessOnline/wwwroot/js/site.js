$(document).ready(function () {
    console.log('ok funziona');
    chessInitialize();
})
var chessPieces = {
    'white': {
        'king': '&#9812',
        'queen': '&#9813',
        'rook': '&#9814',
        'bishop': '&#9815',
        'knight': '&#9816',
        'pawn': '&#9817'
    },
    'black': {
        'king': '&#9818',
        'queen': '&#9819',
        'rook': '&#9820',
        'bishop': '&#9821',
        'knight': '&#9822',
        'pawn': '&#9823'
    }
};
class WhiteSide { };
class BlackSide { };
class Pawn { };
class Bishop { }
class Knight { }
class Rook { }
class Queen { }
class King { }
function chessInitialize() {
    $("#1-1").html(chessPieces.white.rook).add(WhiteSide, Rook);
    $("#1-2").html(chessPieces.white.knight).addClass(WhiteSide, Knight);
    $("#1-3").html(chessPieces.white.bishop).addClass(WhiteSide, Bishop);
    $("#1-4").html(chessPieces.white.queen).addClass(WhiteSide, Queen);
    $("#1-5").html(chessPieces.white.king).addClass(WhiteSide, King);
    $("#1-6").html(chessPieces.white.bishop).addClass(WhiteSide, Bishop);
    $("#1-7").html(chessPieces.white.knight).addClass(WhiteSide, Knight);
    $("#1-8").html(chessPieces.white.rook).addClass(WhiteSide, Rook);
    $("#2-1").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-2").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-3").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-4").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-5").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-6").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-7").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#2-8").html(chessPieces.white.pawn).addClass(WhiteSide, Pawn);
    $("#7-1").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-2").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-3").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-4").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-5").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-6").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-7").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#7-8").html(chessPieces.black.pawn).addClass(BlackSide, Pawn);
    $("#8-1").html(chessPieces.black.rook).addClass(BlackSide, Rook);
    $("#8-2").html(chessPieces.black.knight).addClass(BlackSide, Knight);
    $("#8-3").html(chessPieces.black.pawn).addClass(BlackSide, Bishop);
    $("#8-4").html(chessPieces.black.queen).addClass(BlackSide, Queen);
    $("#8-5").html(chessPieces.black.king).addClass(BlackSide, King);
    $("#8-6").html(chessPieces.black.bishop).addClass(BlackSide, Bishop);
    $("#8-7").html(chessPieces.black.knight).addClass(BlackSide, Knight);
    $("#8-8").html(chessPieces.black.rook).addClass(BlackSide, Rook);

}
function pawnRulez() {

}

function moveChecker() {
    //switch (class) {
    //    case whitePawn:
    //    case blackPawn:
    //        pawnRulez();
    //    case whiteBishop:
    //    case blackBishop:
    //        bishopRulez();
    //    case whiteKnight:
    //    case blackKnight:
    //        knightRulez();
    //    case whiteRook:
    //    case blackRook:
    //        rookRulez();
    //    case whiteQueen:
    //    case blackQueen:
    //        queenRulez();
    //    case whiteKing:
    //    case blackKing:
    //        kingRulez();
    //}
}
