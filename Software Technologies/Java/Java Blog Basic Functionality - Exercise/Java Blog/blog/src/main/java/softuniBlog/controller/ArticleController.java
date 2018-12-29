package softuniBlog.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import softuniBlog.bindingModel.ArticleBindingModel;
import softuniBlog.entity.Article;
import softuniBlog.entity.User;
import softuniBlog.repository.ArticleRepository;
import softuniBlog.repository.UserRepository;

@Controller
public class ArticleController {

    private final UserRepository userRepository;
    private final ArticleRepository articleRepository;

    @Autowired
    public ArticleController(UserRepository userRepository, ArticleRepository articleRepository) {
        this.userRepository = userRepository;
        this.articleRepository = articleRepository;
    }

    @GetMapping("/article/create")
    @PreAuthorize("isAuthenticated()")
    public String create(Model model) {
        model.addAttribute("view", "article/create" );
        return "base-layout";
    }

    @PostMapping("/article/create")
    @PreAuthorize("isAuthenticated()")
    public String createProcess(ArticleBindingModel bindingModel) {
        UserDetails userDetails = (UserDetails) SecurityContextHolder
                .getContext()
                .getAuthentication()
                .getPrincipal();

        User user = this.userRepository.findByEmail(userDetails.getUsername());

        Article article = new Article(
                bindingModel.getTitle(),
                bindingModel.getContent(),
                user
        );

        this.articleRepository.saveAndFlush(article);

        return "redirect:/";

    }

    @GetMapping("/article/{id}")
    public String details(Model model,
                          @PathVariable Integer id) {

//        if (this.articleRepository.exists(id)==false) {
//            return "redirect:/";
//        }

        Article article = this.articleRepository.findOne(id);

        if (article == null) {
            return "redirect:/";
        }

        model.addAttribute("view", "article/details");
        model.addAttribute("article", article);

        return "base-layout";
    }

    @GetMapping("/article/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String edit(Model model,
                       @PathVariable Integer id) {
        Article article = this.articleRepository.findOne(id);

        if (article == null) {
            return "redirect:/";
        }

        model.addAttribute("view", "article/edit");
        model.addAttribute("article", article);

        return "base-layout";
    }

    @PostMapping("/article/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String editProces(@PathVariable Integer id,
                             ArticleBindingModel articleBindingModel) {
        Article article = this.articleRepository.findOne(id);

        if (article == null) {
            return "redirect:/";
        }

        article.setTitle(articleBindingModel.getTitle());
        article.setContent(articleBindingModel.getContent());

        this.articleRepository.saveAndFlush(article);

        return "redirect:/";
    }

    @GetMapping("/article/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String delete(Model model,
                       @PathVariable Integer id) {
        Article article = this.articleRepository.findOne(id);

        if (article == null) {
            return "redirect:/";
        }

        model.addAttribute("view", "article/delete");
        model.addAttribute("article", article);

        return "base-layout";
    }

    @PostMapping("/article/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String deleteProces(@PathVariable Integer id,
                             ArticleBindingModel articleBindingModel) {
        Article article = this.articleRepository.findOne(id);

        if (article == null) {
            return "redirect:/";
        }

        this.articleRepository.delete(article);
        this.articleRepository.flush();

        return "redirect:/";
    }
}
