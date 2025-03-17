$(document).ready(function () {
    advogado_AoCarregarComponente();

    // Verificar se há uma mensagem de sucesso na URL
    var urlParams = new URLSearchParams(window.location.search);
    var sucesso = urlParams.get('sucesso');

    if (sucesso === 'true') {
        advogado_MostrarMensagemSucesso('Ação realizada com sucesso!', '/Content/success.png');
    }
});

function advogado_AoCarregarComponente() {
    $('#advogadoForm').submit(function (event) {
        if (!advogado_ValidarFormulario()) {
            event.preventDefault();
        }
    });

    $('#CEP').blur(advogado_BuscarEnderecoPorCEP);
}

function advogado_ValidarFormulario() {
    var camposValidos = true;

    if ($('#Nome').val() === '') {
        camposValidos = false;
    }
    if ($('#Senioridade').val() === '') {
        camposValidos = false;
    }
    if ($('#Logradouro').val() === '') {
        camposValidos = false;
    }
    if ($('#Bairro').val() === '') {
        camposValidos = false;
    }
    if ($('#Estado').val() === '') {
        camposValidos = false;
    }
    if ($('#CEP').val() === '') {
        camposValidos = false;
    } else {
        var cep = $('#CEP').val();
        var cepValido = advogado_ValidarCEP(cep);

        if (!cepValido) {
            camposValidos = false;
        }
    }
    if ($('#Numero').val() === '') {
        camposValidos = false;
    }

    return camposValidos;
}

function advogado_ValidarCEP(cep) {
    cep = cep.replace(/\D/g, '');

    var regexCEP = /^\d{5}-\d{3}$/;

    if (cep.length === 8) {
        cep = cep.substring(0, 5) + '-' + cep.substring(5, 8);
    }

    var isValid = regexCEP.test(cep);
    return isValid;
}

function advogado_MostrarMensagemErro(mensagem, imagemUrl) {
    var mensagemErro = $('<div class="alert alert-danger mensagem-flutuante"></div>');
    var imagemErro = $('<img src="' + imagemUrl + '" alt="Erro" style="width: 20px; margin-right: 5px;">');

    mensagemErro.append(imagemErro).append(mensagem);
    $('body').append(mensagemErro);

    mensagemErro.addClass('visivel');

    setTimeout(function () {
        mensagemErro.removeClass('visivel');
        setTimeout(function () {
            mensagemErro.remove();
        }, 500);
    }, 3000);
}

function advogado_MostrarMensagemSucesso(mensagem, imagemUrl) {
    var mensagemSucesso = $('<div class="alert alert-success mensagem-flutuante"></div>');
    var imagemSucesso = $('<img src="' + imagemUrl + '" alt="Sucesso" style="width: 20px; margin-right: 5px;">');

    mensagemSucesso.append(imagemSucesso).append(mensagem);
    $('body').append(mensagemSucesso);

    mensagemSucesso.addClass('visivel');

    setTimeout(function () {
        mensagemSucesso.removeClass('visivel');
        setTimeout(function () {
            mensagemSucesso.remove();
        }, 500);
    }, 3000);
}