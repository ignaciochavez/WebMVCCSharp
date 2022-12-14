
function onValidateRut(value) {
    const isRut = '^([0-9]+-{1}[0-9kK]{1})$';
    const regularExpression = new RegExp(isRut);

    if (!regularExpression.test(value)) {
        return false;
    }
    else {
        var arrayValue = value.split('-');
        var rut = arrayValue[0];
        var digitCheck = arrayValue[1];
        if (digitCheck == 'K')
            digitCheck = 'k';

        var M = 0, S = 1;
        for (; rut; rut = Math.floor(rut / 10))
            S = (S + rut % 10 * (9 - M++ % 6)) % 11;

        return digitCheck == (S ? S - 1 : 'k');
    }        
}