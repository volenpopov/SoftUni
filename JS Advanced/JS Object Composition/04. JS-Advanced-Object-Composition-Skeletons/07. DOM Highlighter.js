function highlighter(selector) {
    let target = selector.children;

    if (target.length == 0) {
        selector.addClass('highlight');
        return;
    }

    let tempTarget = target[0];

    while (target.children.length) {
        for (const node of target.children) {
            if (node.children.length > tempTarget.children.length) {
                tempTarget = node;
            }
        }

        target = tempTarget;
    }

    target.addClass('highlight');
    target.parentsUntil(selector.parent()).addClass('highlight');
}