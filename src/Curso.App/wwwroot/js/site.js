$(document).ready(function() {
    // show ajax modal with content
    $(document).on('click', '[data-modal]', function (event) {
        event.preventDefault();
        $.get($(this).data('modal'), function (data) {
            var modal = new bootstrap.Modal($(data));
            var reponseScript = $(data).filter("script");
            $.each(reponseScript, function(idx, val) { 
                eval(val.text);
            } );
            modal.show(); 
        });
    });
    // handle ajax form processing
    $(document).on('submit', 'form', function (event) {
        if(event.currentTarget.id.includes("modal-form-")) event.preventDefault();
        else return;

        var form = $(this);
        var dataForm;
        var contentType = "application/x-www-form-urlencoded";
        var processData = true;
        if(form[0].enctype === "multipart/form-data") {
            contentType = false;
            processData = false;
            dataForm = new FormData(form[0]);
        }
        else dataForm = form.serialize();

        $('.is-invalid').removeClass('is-invalid');
        $('.invalid-feedback').remove();

        $.ajax({
            url: form.attr('action'),
            type: form.attr('method'),
            data: dataForm,
            contentType: contentType,
            processData: processData,
            success: function (data) { 
                if(data.reload) location.reload();
            },
            error: function (data) {
                var bs5Utils = new Bs5Utils();
                $.each(data.responseJSON, function (key, value) {
                    console.log(key, value)
                    bs5Utils.Snack.show('danger', value.errorMessage, 0, true);
                });
            }
        });
    });
})

function BuscaCep(prefixo = 'Endereco_') {
    console.log('started cep finder');
    $(document).ready(function () {

        function limpa_formulário_cep() {
            // Limpa valores do formulário de cep.
            $(`#${prefixo}Logradouro`).val("");
            $(`#${prefixo}Bairro`).val("");
            $(`#${prefixo}Cidade`).val("");
            $(`#${prefixo}Estado`).val("");
        }

        //Quando o campo cep perde o foco.
        $(`#${prefixo}Cep`).blur(function () {

            //Nova variável "cep" somente com dígitos.
            var cep = $(this).val().replace(/\D/g, '');

            //Verifica se campo cep possui valor informado.
            if (cep != "") {

                //Expressão regular para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                    $(`#${prefixo}Logradouro`).val("...");
                    $(`#${prefixo}Bairro`).val("...");
                    $(`#${prefixo}Cidade`).val("...");
                    $(`#${prefixo}Estado`).val("...");

                    //Consulta o webservice viacep.com.br/
                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $(`#${prefixo}Logradouro`).val(dados.logradouro);
                                $(`#${prefixo}Bairro`).val(dados.bairro);
                                $(`#${prefixo}Cidade`).val(dados.localidade);
                                $(`#${prefixo}Estado`).val(dados.uf);
                            } //end if.
                            else {
                                //CEP pesquisado não foi encontrado.
                                limpa_formulário_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                } //end if.
                else {
                    //cep é inválido.
                    limpa_formulário_cep();
                    alert("Formato de CEP inválido.");
                }
            } //end if.
            else {
                //cep sem valor, limpa formulário.
                limpa_formulário_cep();
            }
        });
    });
}

$(document).ready(function () {
    $("#msg_box").fadeOut(2500);
});


function toaster(message) {
    return `<div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header">
            <span class="rounded me-2"></span>
            <strong class="me-auto">Bootstrap</strong>
            <small class="text-muted">just now</small>
            <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
            ${message}
            </div>
            </div>`
}