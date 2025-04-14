# Unity Game

Link para o Jogo:
itch.io
\
**Link para API:**
[Users API](https://67fc1f681f8b41c81685c884.mockapi.io/api/scores/users)

> **GET** Não está tratando o json\
> **NOME** é salvo por **GAMEPLAY**, ao voltar ao menu se digitar um mesmo nome, irá constar como novo usuário

 
## ***🎮 Project Design Document – Caindo na Rede***
#### 📕 Resumo do Jogo
O jogador deve cortar cordas no momento certo para que uma bola de futebol caia diretamente dentro de uma rede. A física do jogo determina o resultado com base no tempo do corte e balanço. Pontuações são registradas em uma API externa para criar um ranking online.\
#### 🚩 Objetivo
- Criar um jogo simples e funcional com física 2D. 
- Rodar fluido em navegadores móveis (Chrome/Safari).
- Garantir jogabilidade fluida e layout adaptável. (Modo Retrato)
- Implementar uma API REST para ranking. (Extra)
#### 🎮 Mecânicas
- Toque para cortar cordas (input por toque ou clique).
- Física para movimentação da bola (gravidade, colisão).
- Condição de vitória: bola cai na rede.
- Condição de derrota: bola cai fora da rede.
- Score: baseado na coleta de estrelas.
- Ranking online: via MockAPI.
#### 📖 Regras do Jogo
- O jogador pode cortar apenas cordas visíveis.
- Cada nível tem uma solução única.
- Reinício rápido após falha.
- Score é por nível é atualizado ao vencer.
  - Score total é salvo ao voltar ao menu.
  
#### 🏗️ Estrutura Básica de Cenas
**MainMenu** – Logo, botão 'Jogar', input nome, botão 'Ranking'\
**GameScene** – Bola pendurada, cordas, rede, física aplicada\
**GameOver** – Tela de derrota ou vitória, botão reiniciar\
**Ranking** – Lista de pontuações (top 5) carregadas da API (TODO)

#### 🖼️ Arte e Som
- Arte: Estilo simples / flat / geométrico (placeholder OK).
- Objetos principais: Bola (sprite), Cordas (sprites com HingeJoint2D), Gol (área de colisão visível)\
- Som: Efeitos simples (corte, vitória, derrota), formato .ogg\
  
#### 📱 Interface (UI)
- UI adaptável para modo retrato(720x1280).
- Usar Canvas Scaler com Scale with Screen Size.
- Botões grandes para toque.
- Feedback visual de vitória/derrota e corte de corda.

#### 🤖 API de Ranking
Base URL: [mockapi](https://67fc1f681f8b41c81685c884.mockapi.io/api/scores/users)
- POST /users: Envia pontuação
- GET /users?sortBy=points&order=desc&limit=5: Top 5

**Campos:**
```csharp
name (string);
score (int);
id (int);
```

#### Critérios de Aceite
[] Carregamento em menos de 5 segundos\
[X] Layout responsivo e em modo retrato\
[X] Jogabilidade funcional com física 2D\
[] FPS mínimo de 30 em celular comum\
[] Jogo sem bugs visíveis ou erros de memória
[] Ranking online funcional (bonus)\
[] Publicado com link público (itch.io)\

#### 🏹 Plano de Execução (3 dias)
Dia 1 – Setup do projeto Unity, layout base, física da bola, mecânica de corte\
Dia 2 – Tela de início, lógica de vitória/derrota, UI, conexão com API de score\
Dia 3 – Polimento, responsividade, testes mobile, publicação no WebGL

## 🎮 Timeline

***Dia 1 (11/04/2025):***\
- Planejamento do GameDesign (15:50 - 17:00)
- Configuração Inicial do Unity (17:00 - 17:50)
- Implementando Funcionalidades Básicas (18:30 - 19:30)*
  - Mecanica de Corte
  - Mecanica de Estrela
  - Mecanica do Gol
  
***Dia 2 (12/04/2025):***
- \* Implementando Funcionalidades Básicas  (08:20 - 13:00) 
- Mecânica do Corte (alteração de Posição do Mouse  para Apenas ao Clicar)
- Buscando Sprites para Substituir os Primitivos (14:20 - 15:40)
- Adicionando Áudio e Interfaces (17:30 - 20:00)
  - Implementado Áudio em Interações * 
  
***Dia 3 (13/04/2025):***
- Adicionando Áudio e Interfaces (8:40 - 12:40)
    - Implementado Áudio em Interações * 
- Adicionando Novos Níveis (13:30 - 16:40)
- Melhorando Sistema de Pontuação (16:40 - 18:40)
- Tentando Implementar API (18:40 - 22:00)
  - **POST da pontuação ao voltar para o menu inicial
  - GET não está tratado
- Bolhas Bolhas

